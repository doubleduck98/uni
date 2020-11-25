#include <avr/io.h>
#include <inttypes.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <util/delay.h>

#include "i2c.h"

#define BAUD 9600                             // baudrate
#define UBRR_VALUE ((F_CPU) / 16 / (BAUD)-1)  // zgodnie ze wzorem

#define i2cCheck(code, msg)                               \
  if ((TWSR & 0xf8) != (code)) {                          \
    printf(msg " failed, status: %.2x\r\n", TWSR & 0xf8); \
    i2cReset();                                           \
    continue;                                             \
  }

// inicjalizacja UART
void uart_init() {
  // ustaw baudrate
  UBRR0 = UBRR_VALUE;
  // wyczyść rejestr UCSR0A
  UCSR0A = 0;
  // włącz odbiornik i nadajnik
  UCSR0B = _BV(RXEN0) | _BV(TXEN0);
  // ustaw format 8n1
  UCSR0C = _BV(UCSZ00) | _BV(UCSZ01);
}

// transmisja jednego znaku
int uart_transmit(char data, FILE *stream) {
  // czekaj aż transmiter gotowy
  while (!(UCSR0A & _BV(UDRE0)))
    ;
  UDR0 = data;
  return 0;
}

// odczyt jednego znaku
int uart_receive(FILE *stream) {
  // czekaj aż znak dostępny
  while (!(UCSR0A & _BV(RXC0)))
    ;
  return UDR0;
}

FILE uart_file;

const uint8_t eeprom_addr = 0xa0;
const char eof_hex[] = ":00000001ff\n";
#define I2C_ROW_SIZE 8

void eeprom_read_byte(uint8_t addr) {
  i2cStart();
  i2cSend(eeprom_addr | ((addr & 0x100) >> 7));
  i2cSend(addr);
  i2cStart();
  i2cSend(eeprom_addr | 0x1 | ((addr & 0x100) >> 7));
  uint8_t data = i2cReadNoAck();
  printf("data: %02x\n", data);
  i2cStop();
}

void eeprom_write_byte(uint8_t addr, uint8_t val) {
  i2cStart();
  i2cSend(eeprom_addr | ((addr & 0x100) >> 7));
  i2cSend(addr);
  i2cSend(val);
  i2cStop();
}

void eeprom_read_n_bytes(uint8_t addr, uint8_t n) {
  while (n > 0) {
    uint8_t to_read = n;
    if (n >= 16) {
      to_read = 16;
    }

    uint8_t data[16];
    uint8_t i = 0;
    uint8_t checksum = 0;
    i2cStart();
    i2cSend(eeprom_addr | ((addr & 0x100) >> 7));
    i2cSend(addr);
    i2cStart();
    i2cSend(eeprom_addr | 0x1 | ((addr & 0x100) >> 7));
    for (; i < to_read - 1; ++i) {
      uint8_t d = i2cReadAck();
      data[i] = d;
      checksum += d;
    }
    data[i] = i2cReadNoAck();
    i2cStop();
    checksum += addr + to_read + data[i];
    checksum = (0x100 - checksum) & 0xff;

    uint8_t i8hex[44];
    i8hex[0] = ':';
    sprintf(&i8hex[1], "%02x", to_read);
    sprintf(&i8hex[3], "%04x", addr);
    sprintf(&i8hex[7], "00");
    for (uint8_t k = 0; k < to_read; ++k) {
      sprintf(&i8hex[9 + (k * 2)], "%02x", data[k]);
    }
    sprintf(&i8hex[9 + (2 * to_read)], "%02x", checksum);
    i8hex[9 + (2 * to_read) + 2] = '\0';
    printf("%s\n", i8hex);

    n -= to_read;
    addr += to_read;
  }
  printf(eof_hex);
}

// 1 jeżeli EOF
// 0 wpp.
uint8_t eeprom_write_bytes(char *i8hex) {
  uint8_t type[3];
  strncpy(type, i8hex + 7, 2);
  type[2] = '\0';
  printf(i8hex);
  // eof
  if (strcmp(type, "01") == 0) {
    printf("eof reached\n");
    return 1;
  }
  // data
  else {
    uint8_t buf[3];
    strncpy(buf, i8hex + 1, 2);
    buf[2] = '\0';
    uint8_t n = strtol(buf, NULL, 16);
    strncpy(buf, i8hex + 5, 2);
    buf[2] = '\0';
    uint8_t addr = strtol(buf, NULL, 16);

    i2cStart();
    i2cSend(eeprom_addr | ((addr & 0x100) >> 7));
    i2cSend(addr);
    // liczba bajtów do konca strony pamięci
    uint8_t page = (I2C_ROW_SIZE - (addr & (I2C_ROW_SIZE - 1)));
    addr += page;
    for (int i = 0; i < n; ++i) {
      // jak zostało 0B na stronie to skaczemy do kolejnej
      if (page == 0) {
        i2cStop();
        i2cStart();
        i2cSend(eeprom_addr | ((addr & 0x100) >> 7));
        i2cSend(addr);
        uint8_t page = (I2C_ROW_SIZE - (addr & (I2C_ROW_SIZE - 1)));
        addr += page;
        if (page > n) page = n;
      }
      // wysyłamy dane
      strncpy(buf, i8hex + 9 + (i * 2), 2);
      buf[2] = '\0';
      uint8_t data = strtol(buf, NULL, 16);
      i2cSend(data);
      --page;
    }
    i2cStop();
    return 0;
  }
}

int main() {
  // zainicjalizuj UART
  uart_init();
  // skonfiguruj strumienie wejścia/wyjścia
  fdev_setup_stream(&uart_file, uart_transmit, uart_receive, _FDEV_SETUP_RW);
  stdin = stdout = stderr = &uart_file;
  // zainicjalizuj I2C
  i2cInit();
  PORTC |= _BV(4) | _BV(5);

  while (1) {
    char buf[64];
    fgets(buf, 64, stdin);
    printf("%s", buf);
    uint8_t *cmd = strtok(buf, " ");
    // instrukcja read
    if (strncmp(cmd, "read", 4) == 0) {
      cmd = strtok(NULL, " ");
      uint8_t addr = (uint8_t)strtol(cmd, NULL, 16);
      // czytamy zakres, jak podalismy coś po adresie
      if ((cmd = strtok(NULL, " ")) != NULL) {
        uint8_t len = (uint8_t)strtol(cmd, NULL, 10);
        eeprom_read_n_bytes(addr, len);
      }
      // czytamy jedną komórkę
      else {
        eeprom_read_byte(addr);
      }
    }
    // instrukcja write
    else if (strncmp(cmd, "write", 5) == 0) {
      cmd = strtok(NULL, " ");
      // jeżeli podamy jakieś liczby, to zakładamy ze
      // piszemy do jednej komórki
      if (cmd != NULL) {
        uint8_t addr = (uint8_t)strtol(cmd, NULL, 16);
        cmd = strtok(NULL, " ");
        uint8_t val = (uint8_t)strtol(cmd, NULL, 16);
        eeprom_write_byte(addr, val);
      }
      // jak nie, to następne wiersze będą danymi w I8HEX
      else {
        while (1) {
          fgets(buf, 64, stdin);
          if (eeprom_write_bytes(buf)) break;
        }
      }
    }
    // cos zle poszło
    else {
      printf("nierozpoznana komenda\n");
    }
    printf("***\n");
  }
}
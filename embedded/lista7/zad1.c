#include <avr/io.h>
#include <inttypes.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <util/delay.h>

#include "i2c.h"

#define BAUD 9600                             // baudrate
#define UBRR_VALUE ((F_CPU) / 16 / (BAUD)-1)  // zgodnie ze wzorem

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

void eeprom_read_byte(uint8_t addr) {
  i2cStart();
  i2cSend(eeprom_addr | ((addr & 0x100) >> 7));
  i2cSend(addr);
  i2cStart();
  i2cSend(eeprom_addr | 0x1 | ((addr & 0x100) >> 7));
  uint8_t data = i2cReadNoAck();
  printf("data: %x\n", data);
  i2cStop();
}

void eeprom_write_byte(uint8_t addr, uint8_t val) {
  i2cStart();
  i2cSend(eeprom_addr | ((addr & 0x100) >> 7));
  i2cSend(addr);
  i2cSend(val);
  i2cStop();
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

  // program testowy
  while (1) {
    char buf[64];
    fgets(buf, 64, stdin);
    printf("%s", buf);
    uint8_t *cmd = strtok(buf, " \n");
    // instrukcja read
    if (strncmp(cmd, "read", 4) == 0) {
      cmd = strtok(NULL, " \n");
      uint8_t addr = (uint8_t)strtol(cmd, NULL, 16);
      eeprom_read_byte(addr);
    }
    // instrukcja write
    else if (strncmp(cmd, "write", 5) == 0) {
      cmd = strtok(NULL, " \n");
      uint8_t addr = (uint8_t)strtol(cmd, NULL, 16);
      cmd = strtok(NULL, " \n");
      uint8_t val = (uint8_t)strtol(cmd, NULL, 16);
      eeprom_write_byte(addr, val);
    }
    // cos zle poszlo
    else {
      printf("nierozpoznana komenda\n");
    }
  }
}

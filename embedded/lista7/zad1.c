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
  uint8_t addr = 0;
#define i2cCheck(code, msg)                               \
  if ((TWSR & 0xf8) != (code)) {                          \
    printf(msg " failed, status: %.2x\r\n", TWSR & 0xf8); \
    i2cReset();                                           \
    continue;                                             \
  }
  while (1) {
    char cmdbuf[64];
    scanf("%s", cmdbuf);
    printf("%s\r\n", cmdbuf);
    if (strcmp(cmdbuf, "read") == 0) {
      printf("r, %s\r\n", cmdbuf);
      uint16_t addr;
      scanf("%x", &addr);
      printf("in, %x\r\n", addr);

      i2cStart();
      i2cSend(eeprom_addr | ((addr & 0x100) >> 7));
      i2cSend(addr);
      i2cStart();
      i2cSend(eeprom_addr | 0x1 | ((addr & 0x100) >> 7));
      uint8_t data = i2cReadNoAck();
      printf("data: %x\r\n", data);
      i2cStop();
    } else if (strcmp(cmdbuf, "write") == 0) {
      printf("w, %s\r\n", cmdbuf);
      uint16_t addr, val;
      scanf("%x %x", &addr, &val);
      printf("in, %x %x\r\n", addr, val);

      i2cStart();
      i2cSend(eeprom_addr | ((addr & 0x100) >> 7));
      i2cSend(addr);
      i2cSend(val);
      i2cStop();
    } else {
      printf("nierozpoznana komenda: %s\r\n", cmdbuf);
    }

    // i2cStart();
    // i2cSend(eeprom_addr | ((10 & 0x100) >> 7));
    // i2cSend(10);
    // i2cStart();
    // i2cSend(eeprom_addr | 0x1 | ((10 & 0x100) >> 7));
    // uint8_t data = i2cReadNoAck();
    // printf("data: %x\r\n", data);
    // i2cStop();

    // i2cStart();
    // i2cSend(eeprom_addr | ((10 & 0x100) >> 7));
    // i2cSend(10);
    // i2cSend(10);
    // i2cStop();
    // _delay_ms(500);

    // i2cStart();
    // i2cCheck(0x08, "I2C start")
    // i2cSend(eeprom_addr | ((addr & 0x100) >> 7));
    // i2cCheck(0x18, "I2C EEPROM write request")
    // i2cSend(addr & 0xff);
    // i2cCheck(0x28, "I2C EEPROM set address")
    // i2cSend(0x00);
    // i2cStart();
    // i2cCheck(0x10, "I2C second start")
    // i2cSend(eeprom_addr |  0x1 | ((addr & 0x100) >> 7));
    // i2cCheck(0x40, "I2C EEPROM read request")
    // uint8_t data = i2cReadNoAck();
    // i2cCheck(0x58, "I2C EEPROM read")
    // i2cStop();
    // i2cCheck(0xf8, "I2C stop")
    // printf("%.3x: %x\r\n", addr, data);
    // addr++;
    // addr &= 0x1ff;
    // _delay_ms(500);
  }
}

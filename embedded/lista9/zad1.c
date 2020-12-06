#include <avr/interrupt.h>
#include <avr/io.h>
#include <avr/sleep.h>
#include <inttypes.h>
#include <stdio.h>
#include <string.h>
#include <util/delay.h>

#include "hd44780.h"

#define BAUD 9600                             // baudrate
#define UBRR_VALUE ((F_CPU) / 16 / (BAUD)-1)  // zgodnie ze wzorem

#define RX_BUFFER_SIZE 32
#define RX_MASK (RX_BUFFER_SIZE - 1)

// bufory cykliczne
static volatile uint8_t rx_buf[RX_BUFFER_SIZE];
static volatile uint8_t rx_head;
static volatile uint8_t rx_tail;

void buf_init() {
  rx_head = 0;
  rx_tail = 0;
}

ISR(USART_RX_vect) {
  uint8_t hd;
  hd = (rx_head + 1) & RX_MASK;
  rx_head = hd;
  rx_buf[hd] = UDR0;
}

int uart_recieve(FILE *stream) {
  uint8_t data, tl;
  cli();
  while (rx_tail == rx_head) {
    sei();
    sleep_mode();
    cli();
  }
  tl = (rx_tail + 1) & RX_MASK;
  rx_tail = tl;
  data = rx_buf[tl];
  sei();
  return data;
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
  // włączam interrupty dla RECIEVE
  UCSR0B |= _BV(RXCIE0);
}

int hd44780_transmit(char data, FILE *stream) {
  LCD_WriteData(data);
  return 0;
}

FILE hd44780_file;
FILE uart_file;

// do wyswietlacza
#define LINE_SIZE 16
static char line1[LINE_SIZE + 1];
static uint8_t line1_str_len = 0;
static uint8_t cur_line = 0;
static uint8_t cur_char = 0;

int main() {
  // skonfiguruj wyświetlacz
  LCD_Initialize();
  LCD_Clear();
  // skonfiguruj strumienie wyjściowe
  fdev_setup_stream(&hd44780_file, hd44780_transmit, NULL, _FDEV_SETUP_WRITE);
  stdout = stderr = &hd44780_file;
  // skonfiguruj uarta i strumien wejsciowy
  uart_init();
  buf_init();
  fdev_setup_stream(&uart_file, NULL, uart_recieve, _FDEV_SETUP_READ);
  stdin = &uart_file;
  sei();
  set_sleep_mode(SLEEP_MODE_IDLE);
  // program testowy
  LCD_WriteCommand(HD44780_DISPLAY_ONOFF | HD44780_DISPLAY_ON |
                   HD44780_CURSOR_ON | HD44780_CURSOR_BLINK);
  while (1) {
    char c = getchar();
    if (c == '\n') {
      continue;
    } else if (c == '\r') {
      LCD_Clear();
      LCD_GoTo(0, 0);
      if (line1_str_len < LINE_SIZE) {
        line1[cur_char + 1] = '\0';
      }
      for (int i = 1; i < 16; ++i) {
        if (line1[i] == '\0' || line1[i] == '\r') break;
        putchar(line1[i]);
      }
      memset(line1, 0, LINE_SIZE);
      LCD_GoTo(0, 1);
      cur_line = 1;
      cur_char = 0;
      line1_str_len = 0;
    } else {
      putchar(c);
      ++cur_char;
      if (cur_line == 1) {
        line1[cur_char] = c;
        if(line1_str_len < LINE_SIZE) { 
          line1_str_len += 1;
        }
      }
      if (cur_char == LINE_SIZE) {
        cur_line = 1 - cur_line;
        LCD_GoTo(0, cur_line);
        cur_char = 0;
      }
    }
  }
}
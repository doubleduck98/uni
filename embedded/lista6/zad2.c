#include <avr/interrupt.h>
#include <avr/io.h>
#include <avr/sleep.h>
#include <inttypes.h>
#include <stdio.h>
#include <util/delay.h>

#define BAUD 9600                             // baudrate
#define UBRR_VALUE ((F_CPU) / 16 / (BAUD)-1)  // zgodnie ze wzorem

#define RX_BUFFER_SIZE 64
#define RX_MASK (RX_BUFFER_SIZE - 1)

#define TX_BUFFER_SIZE 64
#define TX_MASK (TX_BUFFER_SIZE - 1)

// bufory cykliczne
static volatile uint8_t rx_buf[RX_BUFFER_SIZE];
static volatile uint8_t rx_head;
static volatile uint8_t rx_tail;

static volatile uint8_t tx_buf[TX_BUFFER_SIZE];
static volatile uint8_t tx_head;
static volatile uint8_t tx_tail;

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
  // włączam interrupty dla RX
  UCSR0B |= _BV(RXCIE0);
}

void buf_init() {
  rx_head = 0;
  rx_tail = 0;
  tx_head = 0;
  tx_tail = 0;
}

ISR(USART_RX_vect) {
  uint8_t hd;
  hd = (rx_head + 1) & RX_MASK;
  rx_head = hd;
  rx_buf[hd] = UDR0;
}

ISR(USART_TX_vect) { UCSR0B &= ~_BV(UDRIE0); }

ISR(USART_UDRE_vect) {
  uint8_t tl;
  if (tx_tail != tx_head) {
    tl = (tx_tail + 1) & TX_MASK;
    tx_tail = tl;
    UDR0 = tx_buf[tl];
  } else {
    UCSR0B &= ~_BV(UDRIE0);
  }
}

int uart_recieve(FILE *stream) {
  uint8_t data, tl;
  while (rx_tail == rx_head)
    ;
  tl = (rx_tail + 1) & RX_MASK;
  rx_tail = tl;
  data = rx_buf[tl];
  return data;
}

int uart_transmit(char data, FILE *stream) {
  uint8_t hd;
  hd = (tx_head + 1) & TX_MASK;
  while (tx_tail == hd)
    ;
  tx_buf[hd] = data;
  tx_head = hd;
  UCSR0B |= _BV(UDRIE0);
  return 0;
}

FILE uart_file;

int main() {
  uart_init();
  buf_init();
  fdev_setup_stream(&uart_file, uart_transmit, uart_recieve, _FDEV_SETUP_RW);
  stdin = stdout = stderr = &uart_file;
  sei();
  int16_t a;
  scanf("%" SCNd16, &a);
  printf("%" PRId16 "\r\n", a);
  while (1) {
    // printf("skrrt\r\n");
    _delay_ms(500);
  }
}

#include <avr/interrupt.h>
#include <avr/io.h>
#include <avr/sleep.h>
#include <inttypes.h>
#include <stdio.h>
#include <stdlib.h>
#include <util/delay.h>

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

void io_init() {
  // ustaw pull-up na PD2 i PD3 (INT0 i INT1)
  PORTD |= _BV(PORTD2) | _BV(PORTD3);
  // ustaw wyzwalanie przerwania na INT0 i INT1 zboczem narastającym
  EICRA |= _BV(ISC00) | _BV(ISC01) | _BV(ISC10) | _BV(ISC11);
  // odmaskuj przerwania dla INT0 i INT1
  EIMSK |= _BV(INT0) | _BV(INT1);
}

// inicjalizacja ADC
void adc_init() {
  ADMUX = _BV(REFS0) | _BV(MUX3) | _BV(MUX2) | _BV(MUX1);  // internal 1.1V
  DIDR0 = _BV(ADC0D);  // wyłącz wejście cyfrowe na ADC0
  // częstotliwość zegara ADC 125 kHz (16 MHz / 128)
  ADCSRA = _BV(ADPS0) | _BV(ADPS1) | _BV(ADPS2);  // preskaler 128
  ADCSRA |= _BV(ADEN);                            // włącz ADC

  // włączam przerwania
  ADCSRA |= _BV(ADIE);
}

void loop_w_noise() {
  while (1) {
    ADCSRA |= _BV(ADSC);
    while (!(ADCSRA & _BV(ADIF)))
      ;
    ADCSRA |= _BV(ADIF);
    uint32_t a = 1126400 / ADC;
    printf("%" PRIu32 "\r\n", a);
    _delay_ms(10);
  }
}

void loop_wo_noise() {
  set_sleep_mode(SLEEP_MODE_ADC);
  sei();
  while (1) {
    uint32_t a = 1126400 / ADC;
    printf("%" PRIu32 "\r\n", a);
    _delay_ms(10);
    sleep_mode();
  }
}

int main() {
  // zainicjalizuj UART
  uart_init();
  // skonfiguruj strumienie wejścia/wyjścia
  fdev_setup_stream(&uart_file, uart_transmit, uart_receive, _FDEV_SETUP_RW);
  stdin = stdout = stderr = &uart_file;
  // zainicjalizuj wejścia/wyjścia oraz adc
  io_init();
  adc_init();

  // loop_w_noise();
  loop_wo_noise();
}
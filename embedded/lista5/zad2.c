#include <avr/interrupt.h>
#include <avr/io.h>
#include <inttypes.h>
#include <stdio.h>
#include <stdlib.h>

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
  ADMUX = _BV(REFS0);  // referencja AVcc, wejście ADC0
  DIDR0 = _BV(ADC0D);  // wyłącz wejście cyfrowe na ADC0
  // częstotliwość zegara ADC 125 kHz (16 MHz / 128)
  ADCSRA = _BV(ADPS0) | _BV(ADPS1) | _BV(ADPS2);  // preskaler 128
  ADCSRA |= _BV(ADEN);                            // włącz ADC

  // włączam przerwania i autotrigger
  ADCSRA |= _BV(ADIE);
  ADCSRA |= _BV(ADATE);
  // ustawiam źródło na zew. linię przerwania 0
  ADCSRB |= _BV(ADTS1);
}

volatile uint16_t adc_val;
volatile uint8_t adc_res_ready;

ISR(INT0_vect) {}

ISR(ADC_vect) {
  adc_val = ADC;
  adc_res_ready = 1;
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

  // odmaskuj przerwania
  sei();
  while (1) {
    if (adc_res_ready) {
      cli();
      float v = (adc_val * 5) / 1024.0f;
      uint32_t r = v * 10000 / (5 - v);
      printf("%.2f - %" PRIu32 "\r\n", v, r);
      adc_res_ready = 0;
      sei();
    }
  }
}

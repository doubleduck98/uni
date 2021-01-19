#include <avr/interrupt.h>
#include <avr/io.h>
#include <inttypes.h>
#include <math.h>
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

// inicjalizacja ADC
void adc_init() {
  ADMUX = _BV(REFS0) | _BV(REFS1);  // referencja 1.1V internal, wejście ADC0
  DIDR0 = _BV(ADC0D);               // wyłącz wejście cyfrowe na ADC0
  // częstotliwość zegara ADC 125 kHz (16 MHz / 128)
  ADCSRA = _BV(ADPS0) | _BV(ADPS1) | _BV(ADPS2);  // preskaler 128
  ADCSRA |= _BV(ADEN);                            // włącz ADC
}

FILE uart_file;
#define B 3900.0f
#define invT 0.00335f
#define A 0.00013f

int main() {
  uart_init();
  fdev_setup_stream(&uart_file, uart_transmit, uart_receive, _FDEV_SETUP_RW);
  stdin = stdout = stderr = &uart_file;
  adc_init();

  while (1) {
    ADCSRA |= _BV(ADSC);
    while (!(ADCSRA & _BV(ADIF)))
      ;
    ADCSRA |= _BV(ADIF);
    uint16_t ad = ADC;
    float v = (1.1f * ad) / 1024.0f;
    // printf("%f V\n", v);
    float r = v / A;
    // printf("%.2f ohm\n", r);
    float ln = log(r / 4700.0f);
    float _t = invT + (1/B) * ln;
    float t = 1.0f / _t;
    printf("%.2f\n", t - 273.15f);
    _delay_ms(100);
  }
}
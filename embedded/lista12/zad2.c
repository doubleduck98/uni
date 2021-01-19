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

// timer
void timer1_init() {
  // ustaw tryb licznika
  // COM1A = 10   -- non-inverting mode
  // WGM1  = 1110 -- fast PWM top=ICR1
  // CS1   = 101  -- prescaler 1024
  // ICR1  = 1
  // częstotliwość 16e6/(1024*(1+1)) = ~8kHz
  // wzór: datasheet 20.12.3 str. 164
  ICR1 = 1;
  TCCR1A = _BV(COM1A1) | _BV(WGM11);
  TCCR1B = _BV(WGM12) | _BV(WGM13) | _BV(CS10) | _BV(CS12);
  // overflow interrupt
  TIMSK1 |= _BV(TOIE1);
}

// inicjalizacja ADC
void adc_init() {
  ADMUX = _BV(REFS0) | _BV(MUX0);  // wejście ADC1
  DIDR0 = _BV(ADC1D);              // wyłącz wejście cyfrowe na ADC1
  // częstotliwość zegara ADC 125 kHz (16 MHz / 128)
  ADCSRA = _BV(ADPS0) | _BV(ADPS1) | _BV(ADPS2);  // preskaler 128
  ADCSRA |= _BV(ADEN);                            // włącz ADC
  // włączam przerwania i autotrigger
  ADCSRA |= _BV(ADIE) | _BV(ADATE);
  // overflow timera1
  ADCSRB |= _BV(ADTS1) | _BV(ADTS2);
}

#define N_SAMPLES 100
FILE uart_file;
volatile uint16_t n = 0;
volatile float sqsum = 0;

ISR(TIMER1_OVF_vect) {
  ++n;
  if (n >= N_SAMPLES) {
    cli();
  }
}

ISR(ADC_vect) {
  uint16_t ad = ADC;
  float v = (5.0f * ad) / 1024.0f;
  v -= 2.5f;
  // printf("%.2f\n", v);
  sqsum += v * v;
}

int main() {
  uart_init();
  fdev_setup_stream(&uart_file, uart_transmit, uart_receive, _FDEV_SETUP_RW);
  stdin = stdout = stderr = &uart_file;
  timer1_init();
  adc_init();
  sei();

  while (1) {
    if (n >= N_SAMPLES) {
      float avg = sqrt(sqsum / n);
      // printf("%.2f\n", avg);
      float db = 20.0f * log10(avg * sqrt(2) / 2.5);
      printf("%.2f dB\n", db);

      n = 0.0f;
      sqsum = 0.0f;
      sei();
    }
  }
}
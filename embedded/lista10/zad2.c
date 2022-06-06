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

// inicjalizacja ADC
void adc_init() {
  ADMUX = _BV(REFS0);  // referencja AVcc, wejście ADC0
  DIDR0 = _BV(ADC0D);  // wyłącz wejście cyfrowe na ADC0
  // częstotliwość zegara ADC 125 kHz (16 MHz / 128)
  ADCSRA = _BV(ADPS0) | _BV(ADPS1) | _BV(ADPS2);  // preskaler 128
  ADCSRA |= _BV(ADEN);                            // włącz ADC
  // włączam przerwania i autotrigger
  ADCSRA |= _BV(ADIE) | _BV(ADATE);
  // ustawiam źródło na ovf timera1
  ADCSRB |= _BV(ADTS1) | _BV(ADTS2);
}

void timer1_init() {
  // ustaw tryb licznika
  // COM1A = 10   -- non-inverting mode
  // WGM1  = 1000 -- phase and frequency correct PWM top=ICR1
  // CS1   = 101  -- prescaler 1024
  // ICR1  = 30
  // częstotliwość 16e6/(1024*(1+30)) = ~500Hz
  // wzór: datasheet 20.12.3 str. 164
  ICR1 = 30;
  TCCR1A = _BV(COM1A1) | _BV(COM1A0);
  TCCR1B = _BV(WGM13) | _BV(CS10) | _BV(CS12);
  // ustaw pin OC1A (PB1) jako wyjście
  DDRB |= _BV(PB1);
  // overflow interrupt
  TIMSK1 |= _BV(TOIE1);
}

volatile uint16_t a = 1;
uint8_t vals[16] = {128, 96, 64, 48, 32, 28, 24, 20, 16, 14, 12, 10, 8, 6, 4, 2};

ISR(ADC_vect) { a = ADC; }

ISR(TIMER1_OVF_vect) {
    OCR1A = ICR1 / vals[a / 64];}

int main() {
  uart_init();
  fdev_setup_stream(&uart_file, uart_transmit, uart_receive, _FDEV_SETUP_RW);
  stdin = stdout = stderr = &uart_file;
  timer1_init();
  adc_init();
  sei();
  while (1) {
    // OCR1A = ICR1 / vals[a / 64];
    printf("%d\n", a/64);
  }
}
#include <avr/io.h>
#include <inttypes.h>
#include <math.h>
#include <stdio.h>
#include <util/delay.h>

#define BAUD 9600                             // baudrate
#define UBRR_VALUE ((F_CPU) / 16 / (BAUD)-1)  // zgodnie ze wzorem

// inicjalizacja UART
void uart_init() {
    UBRR0 = UBRR_VALUE;
    UCSR0B = _BV(RXEN0) | _BV(TXEN0);
    UCSR0C = _BV(UCSZ00) | _BV(UCSZ01);
}

// transmisja jednego znaku
int uart_transmit(char data, FILE *stream) {
    while (!(UCSR0A & _BV(UDRE0)))
        ;
    UDR0 = data;
    return 0;
}

// odczyt jednego znaku
int uart_receive(FILE *stream) {
    while (!(UCSR0A & _BV(RXC0)))
        ;
    return UDR0;
}

// inicjalizacja ADC
void adc_init() {
    ADMUX = _BV(REFS0);
    DIDR0 = _BV(ADC0D);
    ADCSRA = _BV(ADPS0) | _BV(ADPS1) | _BV(ADPS2);
    ADCSRA |= _BV(ADEN);
}

// timer
void timer1_init() {
    // ustaw tryb licznika
    // COM1A = 10   -- non-inverting mode
    // WGM1  = 1110 -- fast PWM top=ICR1
    // CS1   = 101  -- prescaler 1024
    // ICR1  = 15624
    // częstotliwość 16e6/(1024*(1 + 127)) = ~128Hz
    // wzór: datasheet 20.12.3 str. 164
    ICR1 = 127;
    TCCR1A = _BV(COM1A1) | _BV(WGM11);
    TCCR1B = _BV(WGM12) | _BV(WGM13) | _BV(CS10) | _BV(CS12);
    // ustaw pin OC1A (PB1) jako wyjście
    DDRB |= _BV(PB1);
}

FILE uart_file;

uint8_t vals[16] = {32, 28, 24, 20, 16, 14, 12, 10, 8, 7, 6, 5, 4, 3, 2, 1};

int main() {
    uart_init();
    fdev_setup_stream(&uart_file, uart_transmit, uart_receive, _FDEV_SETUP_RW);
    stdin = stdout = stderr = &uart_file;
    adc_init();
    timer1_init();

    while (1) {
        ADCSRA |= _BV(ADSC);
        while (!(ADCSRA & _BV(ADIF)))
            ;
        ADCSRA |= _BV(ADIF);
        uint16_t v = ADC;
        printf("Odczytano: %" PRIu16 "\r\n", v);
        uint16_t b = vals[v / 64];
        printf("xd: %" PRIu16 "\r\n", b);
        OCR1A = ICR1 / b;
    }
}
#include <avr/io.h>
#include <inttypes.h>
#include <stdio.h>
#include <util/delay.h>
#include <math.h>

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

int uart_receive(FILE *stream) {
    while (!(UCSR0A & _BV(RXC0)))
        ;
    return UDR0;
}

// inicjalizacja ADC
void adc_init() {
    // ustawiam MUX3..0 na 1000, żeby aktywować termistor
    // REFS1 na 1 zgodnie z datasheetem
    ADMUX = _BV(REFS0) | _BV(REFS1) | 0b1000;
    DIDR0 = _BV(ADC0D);
    ADCSRA = _BV(ADPS0) | _BV(ADPS1) | _BV(ADPS2);
    ADCSRA |= _BV(ADEN);
}

FILE uart_file;

#define B 3800

int main() {
    // zainicjalizuj UART
    uart_init();
    fdev_setup_stream(&uart_file, uart_transmit, uart_receive, _FDEV_SETUP_RW);
    stdin = stdout = stderr = &uart_file;
    // zainicjalizuj ADC
    adc_init();

    while (1) {
        ADCSRA |= _BV(ADSC);
        while (!(ADCSRA & _BV(ADIF)))
            ;
        ADCSRA |= _BV(ADIF);
        uint16_t al = ADCL;
        uint16_t ah = ADCH;
        float a = al + (ah << 8);
        float b = a/4700.0f;
        float d = (25.0f * B) / (B + 25.0f * log(b));
        printf("temperatura: %.2f\r\n", d );
        _delay_ms(1000);
    }
}

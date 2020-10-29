#include <avr/io.h>
#include <inttypes.h>
#include <stdio.h>
#include <util/delay.h>

#define BAUD 9600                             // baudrate
#define UBRR_VALUE ((F_CPU) / 16 / (BAUD)-1)  // zgodnie ze wzorem

#define LED PB0
#define LED_PORT PORTB
#define LED_DDR DDRB

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
    // ustawiam MUX3..0 na 1110, żeby mierzyło napięcie wbudowane
    ADMUX = _BV(REFS0) | 0b00001110;
    DIDR0 = _BV(ADC0D);
    ADCSRA = _BV(ADPS0) | _BV(ADPS1) | _BV(ADPS2);
    ADCSRA |= _BV(ADEN);
}

FILE uart_file;

int main() {
    // zainicjalizuj UART
    uart_init();
    fdev_setup_stream(&uart_file, uart_transmit, uart_receive, _FDEV_SETUP_RW);
    stdin = stdout = stderr = &uart_file;
    // zainicjalizuj ADC
    adc_init();
    // zainicjalizuj LEDY
    LED_DDR |= _BV(LED);

    while (1) {
        ADCSRA |= _BV(ADSC);
        while (!(ADCSRA & _BV(ADIF)))
            ;
        ADCSRA |= _BV(ADIF);
        uint16_t al = ADCL;
        uint16_t ah = ADCH;
        float v = (1.1 * 1024) / (al + (ah << 8));
        printf("Odczytano: %f\r\n", v);

        LED_PORT ^= _BV(LED);
        _delay_ms(200);
    }
}

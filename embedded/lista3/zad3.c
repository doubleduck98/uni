#include <avr/io.h>
#include <inttypes.h>
#include <stdio.h>
#define __DELAY_BACKWARD_COMPATIBLE__
#include <util/delay.h>

#define BAUD 9600                             // baudrate
#define UBRR_VALUE ((F_CPU) / 16 / (BAUD)-1)  // zgodnie ze wzorem

#define LED PB5
#define LED_PORT PORTB
#define LED_DDR DDRB

#define BLINK(step, delay)                                                 \
    for (uint16_t i = 0; i < (uint32_t)1000 * (delay) / (step) / 2; i++) { \
        LED_PORT |= _BV(LED);                                              \
        _delay_us(step);                                                   \
        LED_PORT &= ~_BV(LED);                                             \
        _delay_us(step);                                                   \
    }

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
    ADMUX = _BV(REFS0);
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
        uint16_t a = ADC;
        printf("Odczytano: %" PRIu16 "\r\n", a* 4);

        BLINK(8*a, 5);
    }
}

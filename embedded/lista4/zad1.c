#include <avr/io.h>
#include <inttypes.h>
#include <stdio.h>
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

void timer1_init() {
    // ustaw tryb licznika
    // WGM1  = 0000 -- normal
    // CS1   = 001  -- prescaler 1
    TCCR1B = _BV(CS10);
}
FILE uart_file;

void pr8b() {
    printf("8 bitowe liczby:\r\n");
    volatile uint8_t x = 1;
    volatile uint8_t y = 1;
    volatile uint8_t xy = 0;
    uint16_t a = TCNT1;
    xy = x + y;
    uint16_t b = TCNT1;
    printf("dodawanie - czas: %" PRIu16 " cykli\r\n", b - a);
    a = TCNT1;
    xy = x * y;
    b = TCNT1;
    printf("mnozenie - czas: %" PRIu16 " cykli\r\n", b - a);
    a = TCNT1;
    xy = x * y;
    b = TCNT1;
    printf("dzielenie - czas: %" PRIu16 " cykli\r\n", b - a);
    printf("***\r\n");
}

void pr16b() {
    printf("16 bitowe liczby:\r\n");
    volatile uint16_t x = 1;
    volatile uint16_t y = 1;
    volatile uint16_t xy = 0;
    uint16_t a = TCNT1;
    xy = x + y;
    uint16_t b = TCNT1;
    printf("dodawanie - czas: %" PRIu16 " cykli\r\n", b - a);
    a = TCNT1;
    xy = x * y;
    b = TCNT1;
    printf("mnozenie - czas: %" PRIu16 " cykli\r\n", b - a);
    a = TCNT1;
    xy = x * y;
    b = TCNT1;
    printf("dzielenie - czas: %" PRIu16 " cykli\r\n", b - a);
    printf("***\r\n");
}

void pr32b() {
    printf("32 bitowe liczby:\r\n");
    volatile uint32_t x = 1;
    volatile uint32_t y = 1;
    volatile uint32_t xy = 0;
    uint16_t a = TCNT1;
    xy = x + y;
    uint16_t b = TCNT1;
    printf("dodawanie - czas: %" PRIu16 " cykli\r\n", b - a);
    a = TCNT1;
    xy = x * y;
    b = TCNT1;
    printf("mnozenie - czas: %" PRIu16 " cykli\r\n", b - a);
    a = TCNT1;
    xy = x * y;
    b = TCNT1;
    printf("dzielenie - czas: %" PRIu16 " cykli\r\n", b - a);
    printf("***\r\n");
}

void pr64b() {
    printf("64 bitowe liczby:\r\n");
    volatile uint64_t x = 1;
    volatile uint64_t y = 1;
    volatile uint64_t xy = 0;
    uint16_t a = TCNT1;
    xy = x + y;
    uint16_t b = TCNT1;
    printf("dodawanie - czas: %" PRIu16 " cykli\r\n", b - a);
    a = TCNT1;
    xy = x * y;
    b = TCNT1;
    printf("mnozenie - czas: %" PRIu16 " cykli\r\n", b - a);
    a = TCNT1;
    xy = x * y;
    b = TCNT1;
    printf("dzielenie - czas: %" PRIu16 " cykli\r\n", b - a);
    printf("***\r\n");
}

void prfloat() {
    printf("floaty:\r\n");
    volatile float x = 1.0;
    volatile float y = 1.0;
    volatile float xy = 0.0;
    uint16_t a = TCNT1;
    xy = x + y;
    uint16_t b = TCNT1;
    printf("dodawanie - czas: %" PRIu16 " cykli\r\n", b - a);
    a = TCNT1;
    xy = x * y;
    b = TCNT1;
    printf("mnozenie - czas: %" PRIu16 " cykli\r\n", b - a);
    a = TCNT1;
    xy = x * y;
    b = TCNT1;
    printf("dzielenie - czas: %" PRIu16 " cykli\r\n", b - a);
    printf("***\r\n");
}

int main() {
    // zainicjalizuj UART
    uart_init();
    // skonfiguruj strumienie wejścia/wyjścia
    fdev_setup_stream(&uart_file, uart_transmit, uart_receive, _FDEV_SETUP_RW);
    stdin = stdout = stderr = &uart_file;
    // zainicjalizuj licznik
    timer1_init();
    // program testowy
    pr8b();
    pr16b();
    pr32b();
    pr64b();
    prfloat();
    while (1)
        ;
}

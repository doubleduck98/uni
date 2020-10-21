#include <avr/io.h>
#include <inttypes.h>
#include <stdio.h>

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
    // ustaw format 8n1~~
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

void read_8() {
    printf("8b:\r\n");
    int8_t a = 1;
    int8_t b = 1;
    scanf("%" SCNd8, &a);
    scanf("%" SCNd8, &b);
    printf("%" PRId8 "\r\n", a + b);
    printf("%" PRId8 "\r\n", a - b);
    printf("%" PRId8 "\r\n", a * b);
    printf("%" PRId8 "\r\n", a / b);
}

void read_16() {
    printf("16b:\r\n");
    int16_t a = 1;
    int16_t b = 1;
    scanf("%" SCNd16, &a);
    scanf("%" SCNd16, &b);
    printf("%" PRId16 "\r\n", a + b);
    printf("%" PRId16 "\r\n", a - b);
    printf("%" PRId16 "\r\n", a * b);
    printf("%" PRId16 "\r\n", a / b);
}

void read_32() {
    printf("32b:\r\n");
    int32_t a = 1;
    int32_t b = 1;
    scanf("%" SCNd32, &a);
    scanf("%" SCNd32, &b);
    printf("%" PRId32 "\r\n", a + b);
    printf("%" PRId32 "\r\n", a - b);
    printf("%" PRId32 "\r\n", a * b);
    printf("%" PRId32 "\r\n", a / b);
}

void read_64() {
    printf("64b:\r\n");
    int64_t a = 1;
    int64_t b = 1;
    scanf("%" SCNd32, &a);
    scanf("%" SCNd32, &b);
    printf("%" PRId32 "\r\n", a + b);
    printf("%" PRId32 "\r\n", a - b);
    printf("%" PRId32 "\r\n", a * b);
    printf("%" PRId32 "\r\n", a / b);
}

void read_float() {
    printf("float:\r\n");
    float a = 1;
    float b = 1;
    scanf("%f", &a);
    scanf("%f", &b);
    printf("%f\r\n", a + b);
    printf("%f\r\n", a - b);
    printf("%f\r\n", a * b);
    printf("%f\r\n", a / b);
}

int main() {
    // zainicjalizuj UART
    uart_init();
    // skonfiguruj strumienie wejścia/wyjścia
    fdev_setup_stream(&uart_file, uart_transmit, uart_receive, _FDEV_SETUP_RW);
    stdin = stdout = stderr = &uart_file;
    // program testowy
    printf("Hello world!\r\n");
    read_8();
    read_16();
    read_32();
    read_64();
    read_float();
}

#include <avr/io.h>
#include <util/delay.h>

#define LED_DDR DDRD
#define LED_PORT PORTD

#define RESET_BTN PB0
#define INC_BTN PB1
#define DEC_BTN PB2
#define BTN_PORT PORTB
#define BTN_PIN PINB

int button_pressed(int pin) {
    if (bit_is_clear(BTN_PIN, pin)) {
        _delay_ms(5);
        if (bit_is_clear(BTN_PIN, pin)) {
            return 1;
        }
    }
    return 0;
}

int main() {
    UCSR0B &= ~_BV(RXEN0) & ~_BV(TXEN0);
    LED_DDR |= 0xFF;
    LED_PORT &= 0x00;

    BTN_PORT |= _BV(RESET_BTN) | _BV(INC_BTN) | _BV(DEC_BTN);
    uint8_t x = 0x00;
    while (1) {
        if (button_pressed(RESET_BTN)) {
            x = 0x00;
            LED_PORT = 0;
            while (button_pressed(RESET_BTN)) {
            }

        } else if (button_pressed(INC_BTN)) {
            x += 1;
            LED_PORT = x ^ (x >> 1);
            while (button_pressed(INC_BTN)) {
            }

        } else if (button_pressed(DEC_BTN)) {
            x -= 1;
            LED_PORT = x ^ (x >> 1);
            while (button_pressed(DEC_BTN)) {
            }
        }
    }
}
#include <avr/io.h>
#include <util/delay.h>

#define LED_DDR DDRD
#define LED_PORT PORTD

int main() {
    UCSR0B &= ~_BV(RXEN0) & ~_BV(TXEN0);
    // 14.2.1 w manualu, ustawiam porty na output
    LED_DDR |= 0xFF;
    LED_PORT &= 0x00;
	int k = 0;
    while (1) {
        for (k = 1; k < 8; k++) {
			LED_PORT |= (1 << k);
			_delay_ms(100);
			LED_PORT &= ~(1 << k);
		}
        for (k = 6; k >= 0; k--) {
			LED_PORT |= (1 << k);
			_delay_ms(100);
			LED_PORT &= ~(1 << k);
		}
    }
}
#include <avr/io.h>
#include <inttypes.h>
#include <stdio.h>
#include <util/delay.h>

#include "hd44780.h"

#define BAR(n) (n - 1)

int hd44780_transmit(char data, FILE *stream) {
  LCD_WriteData(data);
  return 0;
}

FILE hd44780_file;

uint8_t bars[5][8] = {{0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10},
                      {0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18},
                      {0x1C, 0x1C, 0x1C, 0x1C, 0x1C, 0x1C, 0x1C, 0x1C},
                      {0x1E, 0x1E, 0x1E, 0x1E, 0x1E, 0x1E, 0x1E, 0x1E},
                      {0x1F, 0x1F, 0x1F, 0x1F, 0x1F, 0x1F, 0x1F, 0x1F}};

void write_new_character(uint8_t bar) {
  LCD_WriteCommand(HD44780_CGRAM_SET + (bar * 8));
  for (uint8_t i = 0; i < 8; ++i) {
    LCD_WriteData(bars[bar][i]);
  }
  LCD_WriteCommand(HD44780_DDRAM_SET);
}

void progress(uint8_t prg) {
	LCD_Clear();
  uint8_t times = prg / 5;
  uint8_t rem = prg % 5;
  for (uint8_t i = 0; i < times; i++) {
    LCD_WriteData(BAR(5));
  }
  if (rem > 0) {
    LCD_WriteData(BAR(rem));
  }
}

int main() {
  // skonfiguruj wyświetlacz
  LCD_Initialize();
  LCD_Clear();
  // skonfiguruj strumienie wyjściowe
  fdev_setup_stream(&hd44780_file, hd44780_transmit, NULL, _FDEV_SETUP_WRITE);
  stdout = stderr = &hd44780_file;
  // program testowy
  for (uint8_t i = 0; i < 5; ++i) {
    write_new_character(i);
  }
  while (1) {
    for (uint8_t i = 0; i < 81; i++) {
      LCD_GoTo(0, 0);
      progress(i);
      LCD_GoTo(0, 1);
      printf("%.2" PRIu8, i);
      _delay_ms(200);
    }
  }
}

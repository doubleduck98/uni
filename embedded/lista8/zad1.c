#include <avr/io.h>
#include <stdio.h>

#include "FreeRTOS.h"
#include "task.h"
#include "uart.h"

// drabinka
#define BAR_DDR DDRD
#define BAR_PORT PORTD
// przycisk i lampka
#define BTN_PORT PORTB
#define BTN_PIN PINB
#define BTN PB3
#define LED_DDR DDRB
#define LED_PORT PORTB
#define LED PB5

// bufor
#define BUF_SIZE 256
uint8_t buf[BUF_SIZE];
uint8_t buf_head = 200;
uint8_t buf_tail = 0;

//
#define mainLED_TASK_PRIORITY 1
#define mainLEDBAR_TASK_PRIORITY 1

// function prototypes
static void vBlinkLed(void* pvParameters);
static void vBlinkBar(void* pvParameters);

int main(void) {
  // Create task.
  xTaskHandle blink_handle;
  xTaskHandle bar_handle;

  xTaskCreate(vBlinkLed, "blink", configMINIMAL_STACK_SIZE, NULL,
              mainLED_TASK_PRIORITY, &blink_handle);

  xTaskCreate(vBlinkBar, "bar", configMINIMAL_STACK_SIZE, NULL,
              mainLEDBAR_TASK_PRIORITY, &bar_handle);

  // Start scheduler.
  vTaskStartScheduler();

  return 0;
}

void vApplicationIdleHook(void) {}

static void vBlinkLed(void* pvParameters) {
  LED_DDR |= _BV(LED);
  BTN_PORT |= _BV(BTN);

  for (;;) {
    // sprawdz czy przycisk nacisniety
    if (BTN_PIN & _BV(BTN)) {
      buf[buf_head] = 0;
    } else {
      buf[buf_head] = 1;
    }
    buf_head = (buf_head + 1) & (BUF_SIZE - 1);
    // odczytaj i zapal
    if (buf[buf_tail]) {
      LED_PORT |= _BV(LED);
    } else {
      LED_PORT &= ~_BV(LED);
    }
    buf_tail = (buf_tail + 1) & (BUF_SIZE - 1);
    // odsapnij
    vTaskDelay(5 / portTICK_PERIOD_MS);
  }
}

static void vBlinkBar(void* pvParameters) {
  UCSR0B &= ~_BV(RXEN0) & ~_BV(TXEN0);
  BAR_DDR |= 0xFF;
  BAR_PORT &= 0x00;
  int k = 0;
  while (1) {
    for (k = 1; k < 8; k++) {
      BAR_PORT |= (1 << k);
      vTaskDelay(100 / portTICK_PERIOD_MS);
      BAR_PORT &= ~(1 << k);
    }
    for (k = 6; k >= 0; k--) {
      BAR_PORT |= (1 << k);
      vTaskDelay(100 / portTICK_PERIOD_MS);
      BAR_PORT &= ~(1 << k);
    }
  }
}
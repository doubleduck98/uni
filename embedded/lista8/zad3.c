#include <avr/interrupt.h>
#include <avr/io.h>
#include <stdio.h>

#include "FreeRTOS.h"
#include "better_uart.h"
#include "task.h"

// lampka
#define LED_DDR DDRB
#define LED_PORT PORTB
#define LED PB5

//
#define led_TASK_PRIORITY 1
#define io_TASK_PRIORITY 2

// function prototypes
static void vBlinkLed(void* pvParameters);
static void vIO(void* pvParameters);

int main(void) {
  // Create task.
  xTaskHandle blink_handle;
  xTaskHandle io_handle;
  uart_init();
  stdin = stdout = stderr = &uart_file;
  sei();

  xTaskCreate(vBlinkLed, "blink", configMINIMAL_STACK_SIZE, NULL,
              led_TASK_PRIORITY, &blink_handle);

  xTaskCreate(vIO, "io", configMINIMAL_STACK_SIZE, NULL, io_TASK_PRIORITY,
              &io_handle);

  // Start scheduler.
  vTaskStartScheduler();

  return 0;
}

void vApplicationIdleHook(void) {}

static void vBlinkLed(void* pvParameters) {
  LED_DDR |= _BV(LED);

  for (;;) {
    LED_PORT ^= _BV(LED);
    vTaskDelay(200 / portTICK_PERIOD_MS);
  }
}

static void vIO(void* pvParameters) {
  uint8_t x;

  while (1) {
    scanf("%hd", &x);
    printf("hehexd: %hd\n", x);
  }
}
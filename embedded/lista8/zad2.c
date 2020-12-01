#include <avr/interrupt.h>
#include <avr/io.h>
#include <stdio.h>

#include "FreeRTOS.h"
#include "queue.h"
#include "task.h"
#include "uart.h"

// led
#define LED_DDR DDRB
#define LED_PORT PORTB
#define LED PB5
// kolejka
#define QUEUE_LENGTH 32
#define ITEM_SIZE sizeof(uint16_t)

static QueueHandle_t qHandle = NULL;

// priorytety
#define send_TASK_PRIORITY 1
#define receive_TASK_PRIORITY 1

// function prototypes
static void send_message(void* pvParameters);
static void receive_message(void* pvParameters);

int main() {
  qHandle = xQueueCreate(QUEUE_LENGTH, ITEM_SIZE);
  uart_init();
  stdin = stdout = stderr = &uart_file;
  sei();

  xTaskHandle send;
  xTaskHandle receive;

  xTaskCreate(send_message, "send", configMINIMAL_STACK_SIZE, NULL,
              send_TASK_PRIORITY, &send);

  xTaskCreate(receive_message, "receive", configMINIMAL_STACK_SIZE, NULL,
              receive_TASK_PRIORITY, &receive);

  // Start scheduler.
  vTaskStartScheduler();

  return 0;
}

void vApplicationIdleHook(void) {}

static void send_message(void* pvParameters) {
  uint16_t num;

  while (1) {
    scanf("%d", &num);
    printf("sent: %d\n", num);
    xQueueSend(qHandle, (void*)&num, (TickType_t)10);
  }
}

static void receive_message(void* pvParameters) {
  LED_DDR |= _BV(LED);

  while (1) {
    uint16_t msg;
    if (xQueueReceive(qHandle, &msg, (TickType_t)0) == pdTRUE) {
      printf("received: %d\n", msg);
      LED_PORT |= _BV(LED);
      vTaskDelay(msg / portTICK_PERIOD_MS);
      LED_PORT &= ~_BV(LED);
      vTaskDelay(200 / portTICK_PERIOD_MS);
    }
  }
}
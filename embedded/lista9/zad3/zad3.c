#include <avr/interrupt.h>
#include <avr/io.h>
#include <inttypes.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <util/delay.h>

#include "FreeRTOS.h"
#include "queue.h"
#include "semphr.h"
#include "task.h"
#include "uart.h"

// kolejka
#define QUEUE_LENGTH 16
#define ITEM_SIZE 4UL

static QueueHandle_t qHandle = NULL;
static SemaphoreHandle_t xMutex = NULL;

// priorytety
#define io_TASK_PRIORITY 1
#define thermometer_TASK_PRIORITY 1

// function prototypes
static void io_fun(void* pvParameters);
static void temp_fun(void* pvParameters);

// inicjalizacja ADC
static void adc_init() {
  ADMUX = _BV(REFS0) | _BV(REFS1);
  DIDR0 = _BV(ADC0D);
  ADCSRA = _BV(ADPS0) | _BV(ADPS1) | _BV(ADPS2);
  ADCSRA |= _BV(ADEN);
}

int main() {
  qHandle = xQueueCreate(QUEUE_LENGTH, ITEM_SIZE);
  xMutex = xSemaphoreCreateMutex();
  uart_init();
  stdin = stdout = stderr = &uart_file;
  adc_init();

  xTaskHandle io;
  xTaskHandle thermometer;

  xTaskCreate(io_fun, "io", configMINIMAL_STACK_SIZE, NULL, io_TASK_PRIORITY,
              &io);

  xTaskCreate(temp_fun, "temp", configMINIMAL_STACK_SIZE, NULL,
              thermometer_TASK_PRIORITY, &thermometer);

  // Start scheduler.
  vTaskStartScheduler();

  return 0;
}

static int32_t read_temp() {
  // xSemaphoreTake(xMutex, portMAX_DELAY);
  ADCSRA |= _BV(ADSC);
  while (!(ADCSRA & _BV(ADIF)))
    ;
  ADCSRA |= _BV(ADIF);
  int32_t adc = ADC;
  // xSemaphoreGive(xMutex);
  int32_t v_out = (adc * 1100) / 1024;
  int32_t t_a = (v_out - 500) / 10;
  return t_a;
}

void vApplicationIdleHook(void) {}

static void io_fun(void* pvParameters) {
  while (1) {
    char buf[64];
    fgets(buf, 64, stdin);
    printf("%s", buf);
    uint8_t* cmd = strtok(buf, " ");
    if (strncmp(cmd, "temp", 4) == 0) {
      // ustawiamy nową temperature
      if ((cmd = strtok(NULL, " ")) != NULL) {
        int32_t target_temp = (int)strtol(cmd, NULL, 10);
        // printf("nowa temperatura: %" PRId32 "°C\n", target_temp);
        xQueueSend(qHandle, (void*)&target_temp, portMAX_DELAY);
      }
      // pytamy sie o temperature
      else {
        int32_t temp = read_temp();
        printf("aktualna temperatura: %" PRId32 "°C\n", temp);
      }
    }
    // cos zle poszło
    else {
      printf("nierozpoznana komenda\n");
    }
  }
}

static void temp_fun(void* pvParameters) {
  DDRB |= _BV(PB5);
  int32_t temp;
  int32_t target_temp = 25;
  while (1) {
    // próbujemy odebrać z kolejki
    if (xQueueReceive(qHandle, &target_temp, (TickType_t)0) == pdTRUE) {
      printf("ustawiam nową temperaturę %" PRId32 "°C\n", target_temp);
    }
    // jeżeli obecna temperatura jest mniejsza niż target
    temp = read_temp();
    if (temp < target_temp) {
      // włączamy grzałkę
      PORTB |= _BV(PB5);
    }
    // jak nie, to chłodzimy
    else {
      PORTB &= ~_BV(PB5);
    }
  }
}
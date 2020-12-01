#include <avr/interrupt.h>
#include <avr/io.h>
#include <stdio.h>

#include "FreeRTOS.h"
#include "queue.h"
#include "task.h"
#include "uart.h"
#ifndef F_CPU
#define F_CPU 16000000UL
#endif
#ifndef BAUD
#define BAUD 9600
#endif
#include <util/setbaud.h>
int uart_transmit(char c, FILE *stream);
int uart_receive(FILE *stream);

FILE uart_file = FDEV_SETUP_STREAM(uart_transmit, uart_receive, _FDEV_SETUP_RW);

#define QUEUE_LENGTH 64
#define ITEM_SIZE 1

QueueHandle_t qRxHandle = NULL;
QueueHandle_t qTxHandle = NULL;

void uart_init() {
  UBRR0H = UBRRH_VALUE;
  UBRR0L = UBRRL_VALUE;
#if USE_2X
  UCSR0A |= _BV(U2X0);
#else
  UCSR0A &= ~(_BV(U2X0));
#endif
  UCSR0C = _BV(UCSZ01) | _BV(UCSZ00); /* 8-bit data */
  UCSR0B = _BV(RXEN0) | _BV(TXEN0);   /* Enable RX and TX */
  UCSR0B |= _BV(RXCIE0);              // RX interrupt
  qRxHandle = xQueueCreate(QUEUE_LENGTH, ITEM_SIZE);
  qTxHandle = xQueueCreate(QUEUE_LENGTH, ITEM_SIZE);
}

ISR(USART_RX_vect) {
  uint8_t data;
  BaseType_t xHigher = pdFALSE;
  data = UDR0;
  xQueueSendFromISR(qRxHandle, &data, &xHigher);
  // if (xHigher) {
  //   taskYIELD();
  // }
}

ISR(USART_TX_vect) { UCSR0B &= ~_BV(UDRIE0); }

ISR(USART_UDRE_vect) {
  uint8_t data;
  BaseType_t xHigher = pdFALSE;
  BaseType_t res = xQueueReceiveFromISR(qTxHandle, &data, &xHigher);
  if (res == pdTRUE) {
    UDR0 = data;
  } else {
    UCSR0B &= ~_BV(UDRIE0);
  }
  // if (xHigher) {
  //   taskYIELD();
  // }
}

int uart_transmit(char c, FILE *stream) {
  xQueueSend(qTxHandle, &c, portMAX_DELAY);
  UCSR0B |= _BV(UDRIE0);
  return 0;
}

int uart_receive(FILE *stream) {
  uint8_t data;
  xQueueReceive(qRxHandle, &data, portMAX_DELAY);
  return data;
}

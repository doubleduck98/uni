#include "csapp.h"
#include "queue.h"

typedef struct node {
  SLIST_ENTRY(node) link;
  long value;
} node_t;

typedef SLIST_HEAD(, node) list_t;

node_t *new_node(long value) {
  node_t *node = malloc(sizeof(node_t));
  node->value = value;
  node->link.sle_next = NULL;
  return node;
}

#define N 10

int main(void) {
  list_t head;
  for (int i = 0; i < N; i++){
    node_t *new = new_node(i);
    SLIST_INSERT_HEAD(&head, new, link);
  }
  // nie działa predykat slist_empty
  for (int i = 0; i < N; i++){
    node_t *c = SLIST_FIRST(&head);
    SLIST_REMOVE_HEAD(&head, link);
    free(c);
  }
  return 0;
}
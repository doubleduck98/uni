#include "csapp.h"

int main(int argc, char **argv) {
  struct addrinfo *p, *listp, hints;
  char buf[MAXLINE], srv[MAXLINE];
  int rc, flags;

  if (argc != 3)
    app_error("usage: %s <domain name> <service name>\n", argv[0]);

  /* Get a list of addrinfo records */
  memset(&hints, 0, sizeof(struct addrinfo));
  hints.ai_family = AF_UNSPEC;
  hints.ai_socktype = 0; //SOCK_DGRAM dla tftp, 0 to oba
  /* Connections only */
  if ((rc = getaddrinfo(argv[1], argv[2], &hints, &listp)) != 0)
    gai_error(rc, "getaddrinfo");

  /* Walk the list and display each IP address */
  flags = NI_NUMERICHOST | NI_NUMERICSERV; // adres + numer portu
  for (p = listp; p; p = p->ai_next) {
    Getnameinfo(p->ai_addr, p->ai_addrlen, buf, MAXLINE, srv, MAXLINE, flags);
    printf("%s:%s\n", buf, srv);
  }

  /* Clean up */
  freeaddrinfo(listp);

  return EXIT_SUCCESS;
}

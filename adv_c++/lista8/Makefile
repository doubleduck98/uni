CC =  g++
CC += -fsanitize=address
CPPFLAGS = -std=c++17 -Wall -Wextra

all: zad1 zad2

zad1: zad1.cpp
	$(CC) $(CPPFLAGS) -O2 -o $@ $<

zad2: zad2.cpp
	$(CC) $(CPPFLAGS) -O2 -o $@ $<

clean:
	rm -vf zad1 zad2 zad3 *.o *.csv
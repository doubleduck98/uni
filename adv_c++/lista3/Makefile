CC =  g++
CC += -fsanitize=address
CPPFLAGS = -std=c++17 -Wall -Wextra

all: zad1 zad2 zad3 zad5

zad1: zad1.cpp
	$(CC) $(CPPFLAGS) -O2 -o $@ $<

zad2: zad2.cpp
	$(CC) $(CPPFLAGS) -O2 -o $@ $<

zad3: zad3.cpp
	$(CC) $(CPPFLAGS) -O2 -o $@ $<

zad4: zad4.cpp
	$(CC) $(CPPFLAGS) -O2 -o $@ $<

zad5: zad5.cpp
	$(CC) $(CPPFLAGS) -O2 -o $@ $<

clean:
	rm -vf zad1 zad2 zad3 zad4 zad5 *.o *.txt
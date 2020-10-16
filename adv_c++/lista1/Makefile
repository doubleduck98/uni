CC = g++
# CC += -fsanitize=address
CPPFLAGS = -std=c++17 -Wall -Wextra -trigraphs -Wno-trigraphs

PRG = program

$(PRG): $(PRG).o
	$(CC) $(CPPFLAGS) -o $@ $^

%.o: %.cpp
	$(CC) $(CPPFLAGS) -c -o $@ $<

clean:
	rm -vf $(PRG) *.o
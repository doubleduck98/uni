nominaly = [20, 10, 5, 2, 1]

def main():
    kwota = int(input('Podaj kwote: '))
    for k in nominaly:
        n = 0
        while kwota - k >= 0:
            n += 1
            kwota -= k
        if n != 0:
            print(n, ' x ', k)        

main()
nominaly = [20, 10, 5, 2, 1]

def main():
    kwota = int(input('Podaj kwotę:' ))
    for k in range (0, 5):
        n = 0
        while kwota - nominaly[k] >= 0:
            n += 1
            kwota -= nominaly[k]
        if n != 0:
            print(f'{n} x {nominaly[k]}')        

main()
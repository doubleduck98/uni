import timeit


def czy_pierwsza(n):
    if n == 2:
        return True
    for i in range(2, n):
        if n % i == 0:
            return False
    return True


def pierwsze():
    yield 2
    i = 3
    while(True):
        yield i
        i += 2
        while(not czy_pierwsza(i)):
            i += 2


def pierwsze_generator(n):
    p = pierwsze()
    return [next(p) for _ in range(n+1)]


def pierwsze_imperatywna(n):
    pierwsze = []
    for i in range(2, n+1):
        if czy_pierwsza(i):
            pierwsze.append(i)
    return pierwsze


def pierwsze_skladana(n):
    return [i for i in range(2, n+1) if czy_pierwsza(i)]


def pierwsze_funkcyjna(n):
    return list(filter(lambda x: czy_pierwsza(x), range(2, n+1)))


def gnuplot(punkty):
    def pkty_dla_generatora():
        return [len(pierwsze_skladana(n)) for n in punkty]

    def timer(n, fun):
        return str(timeit.Timer(f'{fun}({n})',
                                globals=globals()).timeit(10) / 10)
    gen = pkty_dla_generatora()
    dat = open("plot.dat", "w")
    dat.write("#\tX\tgenerator\timperatywna\tskladana\tfunkcyjna\n")
    for n in range(0, len(punkty)):
        dat.write(
            f'{punkty[n]}\t{timer(gen[n], "pierwsze_generator")}\t{timer(punkty[n], "pierwsze_imperatywna")}\t{timer(punkty[n], "pierwsze_skladana")}\t{timer(punkty[n], "pierwsze_funkcyjna")}\n')
    dat.close()


gnuplot([x for x in range(100, 1000, 100)])

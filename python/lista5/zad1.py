import timeit
import subprocess as sub


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


def pierwsze_generator(n):
    p = pierwsze()
    return [p.__next__() for _ in range(1, n+1)]


print(timeit.Timer('pierwsze_imperatywna(50)',
                   globals=globals()).timeit(50))
print(timeit.Timer('pierwsze_skladana(50)',
                   globals=globals()).timeit(50))
print(timeit.Timer('pierwsze_funkcyjna(50)',
                   globals=globals()).timeit(50))
print(timeit.Timer('pierwsze_generator(15)',
                   globals=globals()).timeit(50))


def gnuplot(punkty):
    def maxy_dla_generatora():
        return [len(pierwsze_skladana(n)) for n in punkty]

    def timer_imp(n):
        return str(timeit.Timer(f'pierwsze_imperatywna({n})',
                                globals=globals()).timeit(1))

    def timer_fun(n):
        return str(timeit.Timer(f'pierwsze_funkcyjna({n})',
                                globals=globals()).timeit(1))

    def timer_skl(n):
        return str(timeit.Timer(f'pierwsze_skladana({n})',
                                globals=globals()).timeit(1))

    def timer_gen(n):
        return str(timeit.Timer(f'pierwsze_generator({n})',
                                globals=globals()).timeit(1))
    gen = maxy_dla_generatora()
    dat = open("plot.dat", "w")
    dat.write("#\tX\tgenerator\timperatywna\tskladana\tfunkcyjna\n")
    for n in range(0, len(punkty)):
        dat.write(
            f'{punkty[n]}\t{timer_gen(gen[n])}\t{timer_imp(punkty[n])}\t{timer_skl(punkty[n])}\t{timer_fun(punkty[n])}\n')
    dat.close()
    file_optput = open('plot.png', 'w+')
    sub.run(['gnuplot', 'plot.gp'], stdout=file_optput,
            cwd=r'/home/szipi/uni/python/lista5/')
    file_optput.close()


gnuplot([x for x in range(100, 4000, 200)])

import timeit


def czy_pierwsza(n):
    if n == 2:
        return True
    for i in range(2, n):
        if n % i == 0:
            return False
    return True


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


print(timeit.Timer('pierwsze_imperatywna(1000)',
                   globals=globals()).timeit(10) / 10)
print(timeit.Timer('pierwsze_funkcyjna(1000)',
                   globals=globals()).timeit(10) / 10)
print(timeit.Timer('pierwsze_funkcyjna(1000)',
                   globals=globals()).timeit(10) / 10)

print(pierwsze_funkcyjna(50) == pierwsze_imperatywna(50) == pierwsze_skladana(50))

print(pierwsze_funkcyjna(50))

import timeit


def czy_doskonala(n):
    cyf = [i for i in range(1, n) if n % i == 0]
    return n == sum(cyf)


def doskonale_imperatywna(n):
    res = []
    for i in range(1, n+1):
        if czy_doskonala(i):
            res.append(i)
    return res


def doskonale_skladana(n):
    return [i for i in range(1, n+1) if czy_doskonala(i)]

def doskonale_funkcyjna(n):
    return list(filter(lambda x: czy_doskonala(x), range(1, n+1)))


print(timeit.Timer('doskonale_imperatywna(1000)',
                   globals=globals()).timeit(10) / 10)
print(timeit.Timer('doskonale_funkcyjna(1000)',
                   globals=globals()).timeit(10) / 10)
print(timeit.Timer('doskonale_funkcyjna(1000)',
                   globals=globals()).timeit(10) / 10)

print(doskonale_funkcyjna(500) == doskonale_imperatywna(500) == doskonale_skladana(500))

print(doskonale_funkcyjna(500))



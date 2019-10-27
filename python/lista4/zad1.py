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
    return filter()

print(pierwsze_imperatywna(20))
print(pierwsze_skladana(20))
def rozklad(n):
    if n == 1:
        return [(1,1)]
    res = []
    x = 2
    while n > 1:
        k = 0
        while n % x == 0:
            k += 1
            n /= x
        if k != 0:
            res.append((x, k))
        x += 1
    return res

print(rozklad(int(input("Podaj liczbę > 0: "))))
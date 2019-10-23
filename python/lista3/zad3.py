acc = {}

def sudan(n, x, y):
    if str((n, x, y)) in acc:
        return acc[str((n, x, y))]
    elif n == 0:
        return x + y
    elif y == 0:
        return x
    else:
        acc[str((n, x, y))] = sudan(n - 1, sudan(n, x, y - 1), sudan(n, x, y - 1) + y)
        return acc[str((n, x, y))]


print(sudan(1, 4, 14))
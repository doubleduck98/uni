def pierwiastek(n):
    sum = 0
    i = 1
    while sum < n:
        i += 1
        sum += 2 * i - 1

    return i-1


for i in range(0, 146, 5):
    print(f'{i} -> {pierwiastek(i)}')

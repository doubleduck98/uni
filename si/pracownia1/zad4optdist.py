def opt_dist(list, D):
    # tablica sum prefiksowych
    pref = [0 for _ in range(len(list) + 1)]
    for i in range(1, len(list) + 1):
        pref[i] = pref[i-1] + list[i-1]

    res = len(list)
    # przechodzimy po kolei okienkiem długości D
    for i in range(len(list) - D + 1):
        end = i + D - 1
        curr = pref[end+1] - pref[i]
        before = pref[i]
        after = pref[len(list)] - pref[end+1]
        res = min(res, D - curr + before + after)
    return res


if __name__ == '__main__':

    res = open('./zad4_output.txt', 'w')

    with open('./zad4_input.txt') as inp:
        for linijka in inp:
            lista, d = linijka.split()
            lista = [int(ch) for ch in lista]
            res.write(f'{opt_dist(lista, int(d))}\n')

    res.close()

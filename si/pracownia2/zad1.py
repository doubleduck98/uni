from copy import deepcopy

rows, cols, obr = list(), list(), list()


def set_char(str, i, ch):
    lst = list(str)
    lst[i] = ch
    return ''.join(lst)


def koniec():
    return all('?' not in o for o in obr)


def dobra_linia(linia, bloki):
    linia = '.' + linia + '.'
    l_komorek = len(linia)
    l_blokow = len(bloki)
    dp = [[False] * (l_blokow + 1) for _ in range(l_komorek + 1)]
    dp[0][0] = True

    for i in range(l_komorek-1):
        for j in range(l_blokow + 1):
            if dp[i][j]:
                if linia[i + 1] != '#':
                    dp[i+1][j] = True

                # nie wychodzimy poza planszę
                if j < l_blokow and i+bloki[j]+1 < l_komorek:
                    # blok ma określoną długość i jest spójny
                    if linia[i+bloki[j]+1] != '#' and '.' not in linia[i+1:i+bloki[j]+1]:
                        dp[i+bloki[j]+1][j+1] = True

    return dp[l_komorek-1][l_blokow]


def czy_dobry_krok(i, j, znak):
    ob_obr = deepcopy(obr)
    ob_obr[i] = set_char(ob_obr[i], j, znak)

    wiersz = ob_obr[i]
    kolumna = ''.join([ob_obr[x][j] for x in range(len(ob_obr))])
    return dobra_linia(wiersz, rows[i]) and dobra_linia(kolumna, cols[j])


def rozwaz_pozycje(i, j):
    # jeżeli tylko jedno ustawienie pasuje, to je ustawiamy
    plotek = czy_dobry_krok(i, j, '#')
    kropka = czy_dobry_krok(i, j, '.')
    if plotek and not kropka:
        obr[i] = set_char(obr[i], j, '#')
        return
    elif kropka and not plotek:
        obr[i] = set_char(obr[i], j, '.')
        return


def solve():
    nrows, ncols = len(rows), len(cols)

    while not koniec():
        # draw()
        for i in range(nrows):
            for j in range(ncols):
                # jezeli jestesmy pewni co do komórki to jej nie rozwazamy
                if obr[i][j] == '?':
                    rozwaz_pozycje(i, j)


def draw():
    for row in obr:
        print(row)
    print()


def save():
    with open('zad_output.txt', 'w') as out:
        for o in obr:
            out.write(o + '\n')


if __name__ == "__main__":
    with open('zad_input.txt') as inp:
        nrows, ncols = inp.readline().split()
        for _ in range(int(nrows)):
            rows.append(tuple([int(x) for x in inp.readline().split()]))
        for _ in range(int(ncols)):
            cols.append(tuple([int(x) for x in inp.readline().split()]))
    obr = ['?' * int(ncols) for i in range(int(nrows))]

    solve()
    save()
    draw()
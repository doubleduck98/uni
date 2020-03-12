# zbiór wszystkich slow ze slownika
SLOWA = set()


def przeroblinie(linia):
    literki = []
    literki.append('')
    for literka in linia:
        literki.append(literka)

    # S[n] jest true jak istnieje podciąg będący słowem kończący się w n
    S = [False for _ in range(len(literki))]
    S[0] = True
    for k in range(1, len(literki)):
        for j in range(1, k+1):
            if ''.join(literki[j:k+1]) in SLOWA:
                S[k] = True

    # D[n] początki slowa kończącego się w n
    D = [[] for _ in range(len(literki))]
    for k in range(1, len(literki)):
        for j in range(1, k+1):
            if S[k] and ''.join(literki[j:k+1]) in SLOWA:
                D[k].append(j)

    # comp -> lista możliwych początków, numer, literka
    comp = [[D[x], x, literki[x]] for x in range(len(literki))]

    # teraz dla kazdej literki mamy początki słowa, które ta literka kończy
    # i znajdujemy ciągi poprawnych wyrazów maxujące sumy kwadratow

    # dp -> suma, poczatek, literka
    dp = [[0, -1, literki[x]] for x in range(len(literki))]
    for akt in range(1, len(literki)):
        poczatki = comp[akt][0]
        akt_suma = 0
        max_pocz = 0
        for pocz in poczatki:
            # dod to ile dodamy do sumy
            dod = (comp[akt][1] - pocz + 1) ** 2
            # bierzemy sume przed początkiem i bierzemy maxa
            pre_sum = dp[pocz-1][0]
            # akt_suma = max(akt_suma, pre_sum + dod)
            if pre_sum + dod > akt_suma:
                akt_suma = pre_sum + dod
                max_pocz = comp[pocz][1]
        dp[akt][0] = akt_suma
        dp[akt][1] = max_pocz

    return dobre_zdanie(dp, literki)


def dobre_zdanie(dp, literki):
    res = []
    ret = ''
    koniec = len(literki)-1
    while koniec > 0:
        pocz = dp[koniec][1]
        res.append(literki[pocz:koniec+1])
        koniec = pocz-1
    for slowo in reversed(res):
        sl = ''.join(slowo)
        ret += sl + ' '
    return ret


if __name__ == '__main__':
    with open('./words_for_ai1.txt', 'r') as slownik:
        for slowo in slownik:
            SLOWA.add(slowo.strip('\n'))

    res = open('./zad2_output.txt', 'w')

    with open('./zad2_input.txt') as pan_tadeusz:
        for linijka in pan_tadeusz:
            lin = linijka.strip('\n')
            przerobiona = przeroblinie(lin)
            res.write(f'{przerobiona}\n')

    res.close()

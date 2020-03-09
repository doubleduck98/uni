from collections import deque


# zbiór wszystkich slow ze slownika
SLOWA = set()


def przeroblinie(linia):
    literki = []
    literki.append('')
    for literka in linia:
        literki.append(literka)
    # print(literki[1:])

    # S[n] jest true jak istnieje podciąg będący słowem kończący się w n
    S = [False] * len(literki)
    S[0] = True
    for k in range(1, len(literki)):
        for j in range(1, k+1):
            if ''.join(literki[j:k+1]) in SLOWA:
                # print(''.join(literki[j:k+1]))
                S[k] = True
    # print(S[1:])

    # D[n] początki slowa kończącego się w n
    D = [[] for _ in range(len(literki))]
    for k in range(1, len(literki)):
        for j in range(1, k+1):
            if S[k] and ''.join(literki[j:k+1]) in SLOWA:
                D[k].append(j)

    # comp -> lista możliwych początków, numer, literka
    comp = [[D[x], x, literki[x]] for x in range(0, len(literki))]
    for x in comp:
        print(x)
    # teraz dla kazdej literki mamy początki słowa, które ta literka kończy
    # i znajdujemy ciągi poprawnych wyrazów maxujące sumy kwadratow
    
    
    # TODO: NO RESZTE HEHE


if __name__ == '__main__':
    with open('./words_for_ai1.txt', 'r') as slownik:
        for slowo in slownik:
            SLOWA.add(slowo.strip('\n'))

    # res = open('./zad2_output.txt', 'w')

    # with open('./zad2_input.txt') as pan_tadeusz:
    #     for linijka in pan_tadeusz:
    #         przerobiona = przeroblinie(linijka)
    #         res.write(f'{przerobiona}\n')

przeroblinie('tamatematykapustkinieznosi')

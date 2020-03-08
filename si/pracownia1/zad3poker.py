from itertools import product
from random import sample
import argparse

kolorl = [
    '\u2664',
    '\u2665',
    '\u2666',
    '\u2667'
]

blotka = {
    '2': 1,
    '3': 2,
    '4': 3,
    '5': 4,
    '6': 5,
    '7': 6,
    '8': 7,
    '9': 8,
    '10': 9
}

figura = {
    'J': 10,
    'Q': 11,
    'K': 12,
    'A': 13
}


# [('2', '♦'), ('6', '♦'), ('5', '♦'), ('10', '♤'), ('7', '♦')]
# [('K', '♧'), ('K', '♤'), ('A', '♧'), ('J', '♥'), ('A', '♥')]
karty_blotkarza = set(product(blotka, kolorl))
karty_figuranta = set(product(figura, kolorl))
wszystkie_karty = {**blotka, **figura}


def losuj_talie_blotkarza():
    return sample(karty_blotkarza, k=5)


def losuj_talie_figuranta():
    return sample(karty_figuranta, k=5)


# układy, poker krolewski nie siądzie w naszym zadanku
uklady = [('poker', 9), ('kareta', 8), ('ful', 7), ('kolor', 6),
          ('strit', 5), ('trojka', 4), ('dwie_pary', 3), ('para', 2)]


def poker(reka):
    return kolor(reka) and strit(reka)


def kareta(reka):
    container = set()
    sparowane = set()
    strojkowane = set()
    reka_stripped = list(map(lambda p: p[0], reka))
    for x in reka_stripped:
        if x in strojkowane:
            return True
        elif x in sparowane:
            strojkowane.add(x)
        elif x in container:
            sparowane.add(x)
        else:
            container.add(x)
    return False


def ful(reka):
    container = set()
    sparowane = set()
    strojkowane = set()
    reka_stripped = list(map(lambda p: p[0], reka))
    for x in reka_stripped:
        if x in sparowane:
            strojkowane.add(x)
        elif x in container:
            sparowane.add(x)
        else:
            container.add(x)
    return len(strojkowane) == 1 and len(sparowane) == 2


def kolor(reka):
    container = set()
    reka_stripped = list(map(lambda p: p[1], reka))
    for x in reka_stripped:
        container.add(x)
    return len(container) == 1


def strit(reka):
    reka_stripped = list(map(lambda p: wszystkie_karty[p[0]], reka))
    reka_stripped.sort()
    for i in range(len(reka_stripped) - 1):
        if reka_stripped[i] != reka_stripped[i+1] - 1:
            return False
    return True


def trojka(reka):
    container = set()
    sparowane = set()
    reka_stripped = list(map(lambda p: p[0], reka))
    for x in reka_stripped:
        if x in sparowane:
            return True
        elif x in container:
            sparowane.add(x)
        else:
            container.add(x)
    return False


def dwie_pary(reka):
    container = set()
    sparowane = set()
    reka_stripped = list(map(lambda p: p[0], reka))
    for x in reka_stripped:
        if x in container:
            sparowane.add(x)
            if len(sparowane) == 2:
                return True
        else:
            container.add(x)
    return False


def para(reka):
    container = set()
    reka_stripped = list(map(lambda p: p[0], reka))
    for x in reka_stripped:
        if x in container:
            return True
        else:
            container.add(x)
    return False


# porownywanie
figurant_wygrywa = 0
blotkarz_wygrywa = 0


def rozdanie():
    global figurant_wygrywa, blotkarz_wygrywa

    reka_figuranta, wartosc_fig = losuj_talie_figuranta(), 1
    reka_blotkarza, wartosc_blt = losuj_talie_blotkarza(), 1
    # reka_blotkarza, wartosc_blt = [('5', '♤'), ('8', '♦'), ('5', '♥'), ('8', '♤'), ('5', '♦')], 1
    # reka_blotkarza, wartosc_blt = [('8', '♤'), ('8', '♥'), ('8', '♦'), ('8', '♧'), ('6', '♥')] , 1

    for test, wart in uklady:
        if eval(f'{test}(reka_figuranta)'):
            wartosc_fig = wart
            break

    for test, wart in uklady:
        if eval(f'{test}(reka_blotkarza)'):
            wartosc_blt = wart
            break

    # jezeli są takie same układy, to figurant wygrywa
    # bo ma silniejszą pare/karte
    if wartosc_fig == wartosc_blt:
        figurant_wygrywa += 1
    elif wartosc_fig > wartosc_blt:
        figurant_wygrywa += 1
    else:
        blotkarz_wygrywa += 1


def monte_carlo(n):
    global figurant_wygrywa, blotkarz_wygrywa

    for _ in range(n):
        rozdanie()

    procent = figurant_wygrywa / (figurant_wygrywa + blotkarz_wygrywa)
    print('Figurant wygrał ' + "{:.2%}".format(procent) +
          f' rozdań. ({figurant_wygrywa} z {figurant_wygrywa + blotkarz_wygrywa})')


if __name__ == '__main__':
    def get_argparser():
        parser = argparse.ArgumentParser()
        parser.add_argument('-n', default=10000,
                            help='Ilość wygenerowanych rozdań.')
        return parser

    parser = get_argparser()
    args = parser.parse_args()

    monte_carlo(int(args.n))

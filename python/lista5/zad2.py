from itertools import product
from functools import reduce


def wypisz_ladnie(slownik, slowa):
    def liczba(slowo, slownik):
        return reduce((lambda x, y: x*10 + y), map((lambda x: slownik[x]), slowo))
    print(slownik)
    print(''.join(str(liczba(slowa[0], slownik)).rjust(
        len(str(liczba(slowa[2], slownik)))+1)))
    print('+'+''.join(str(liczba(slowa[1], slownik)
                          ).rjust(len(str(liczba(slowa[2], slownik))))))
    print('='+''.join(str(liczba(slowa[2], slownik)
                          ).rjust(len(str(liczba(slowa[2], slownik))))))


def kryptoarytm(pierwsze, drugie, trzecie):

    def liczba(slowo, slownik):
        return reduce((lambda x, y: x*10 + y), map((lambda x: slownik[x]), slowo))

    def czy_rowna_sie(slownik): 
        if liczba(pierwsze, slownik) + liczba(drugie, slownik) == liczba(trzecie, slownik):
            wypisz_ladnie(slownik, [pierwsze, drugie, trzecie])
    literki = set(char for char in (pierwsze+drugie+trzecie))
    wartosci = product((0, 1, 2, 3, 4, 5, 6, 7, 8, 9), repeat=len(literki))
    for wart in wartosci:
        czy_rowna_sie(dict(zip(literki, wart)))


kryptoarytm("KIOTO", "OSAKA", "TOKIO")

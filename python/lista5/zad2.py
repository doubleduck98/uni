from itertools import product
from functools import reduce


def wypisz_ladnie(slownik, slowa):
    def suma(slowo, slownik):
        return reduce((lambda x, y: x*10 + y), map((lambda x: slownik[x]), slowo))
    print(slownik)
    print(''.join(str(suma(slowa[0], slownik)).rjust(
        len(str(suma(slowa[2], slownik)))+1)))
    print('+'+''.join(str(suma(slowa[1], slownik)
                          ).rjust(len(str(suma(slowa[2], slownik))))))
    print('='+''.join(str(suma(slowa[2], slownik)
                          ).rjust(len(str(suma(slowa[2], slownik))))))


def kryptoarm(pierwsze, drugie, trzecie):

    def czy_rowna_sie(slownik):
        if suma(pierwsze, slownik) + suma(drugie, slownik) == suma(trzecie, slownik):
            wypisz_ladnie(slownik, [pierwsze, drugie, trzecie])

    def suma(slowo, slownik):
        return reduce((lambda x, y: x*10 + y), map((lambda x: slownik[x]), slowo))
    literki = set(char for char in (pierwsze+drugie+trzecie))
    wszystkie = [dict(zip(literki, wartosci)) for wartosci in list(
        product((0, 1, 2, 3, 4, 5, 6, 7, 8, 9), repeat=len(literki)))]
    for slw in wszystkie:
        czy_rowna_sie(slw)


kryptoarm("KIOTO", "OSAKA", "TOKIO")

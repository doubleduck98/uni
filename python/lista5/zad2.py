from itertools import product
from functools import reduce


def kryptoarm(pierwsze, drugie, wynik):

    def suma(slowo, slownik):
        lit = [char for char in slowo]
        suma = 0
        for i in lit:
            suma = 10*suma + slownik[i]
        return suma

    def czy_rowna_sie(slownik):
        hm = suma(pierwsze, slownik) + suma(drugie,
                                            slownik) == suma(wynik, slownik)
        if hm:
            print(slownik)
    literki = set(char for char in (pierwsze+drugie+wynik))
    wszystkie = [dict(zip(literki, wartosci)) for wartosci in list(
        product((0, 1, 2, 3, 4, 5, 6, 7, 8, 9), repeat=len(literki)))]
    # print(wszystkie)
    for slw in wszystkie:
        czy_rowna_sie(slw)


kryptoarm("KIOTO", "OSAKA", "TOKIO")

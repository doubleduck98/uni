from itertools import product


class Formula:
    def zmienne(self, zbior_zmiennych=set()):
        if isinstance(self, Zmienna):
            zbior_zmiennych.add(self.nazwa)
            return zbior_zmiennych
        elif isinstance(self, (T, F)):
            return zbior_zmiennych
        elif isinstance(self, Negacja):
            return self.formula.zmienne(zbior_zmiennych)
        else:
            return self.f1.zmienne(zbior_zmiennych) | self.f2.zmienne(zbior_zmiennych)

    def tautologia(self):
        zmienne = self.zmienne(set())
        wszystkie_zmienne = [dict(zip(zmienne, wartosc))
                             for wartosc in list(product((True, False), repeat=len(zmienne)))]
        return all(self.oblicz(zmienne) for zmienne in wszystkie_zmienne)


class T(Formula):
    def oblicz(self, zmienne={}):
        return True

    def __str__(self):
        return 'True'


class F(Formula):
    def oblicz(self, zmienne={}):
        return False

    def __str__(self):
        return 'False'


class Zmienna(Formula):
    def __init__(self, nazwa_zmiennej):
        self.nazwa = nazwa_zmiennej

    def oblicz(self, zmienne={}):
        if self.nazwa not in zmienne:
            raise Exception(
                f'Nie znaleziono zmiennej {self.nazwa} w liście zmiennych.')
        return zmienne[self.nazwa]

    def __str__(self):
        return self.nazwa


class Negacja(Formula):
    def __init__(self, formula):
        self.formula = formula

    def oblicz(self, zmienne={}):
        return not self.formula.oblicz(zmienne)

    def __str__(self):
        return f'~({self.formula.__str__()})'


class Koniunkcja(Formula):
    def __init__(self, formula1, formula2):
        self.f1 = formula1
        self.f2 = formula2

    def oblicz(self, zmienne={}):
        return self.f1.oblicz(zmienne) and self.f2.oblicz(zmienne)

    def __str__(self):
        return f'{self.f1.__str__()} ^ {self.f2.__str__()}'


class Alternatywa(Formula):
    def __init__(self, formula1, formula2):
        self.f1 = formula1
        self.f2 = formula2

    def oblicz(self, zmienne={}):
        return self.f1.oblicz(zmienne) or self.f2.oblicz(zmienne)

    def __str__(self):
        return f'{self.f1.__str__()} v {self.f2.__str__()}'


class Implikacja(Formula):
    def __init__(self, formula1, formula2):
        self.f1 = formula1
        self.f2 = formula2

    def oblicz(self, zmienne={}):
        return not(self.f1.oblicz(zmienne)) or self.f2.oblicz(zmienne)

    def __str__(self):
        return f'{self.f1.__str__()} => {self.f2.__str__()}'


class Rownowaznosc(Formula):
    def __init__(self, formula1, formula2):
        self.f1 = formula1
        self.f2 = formula2

    def oblicz(self, zmienne={}):
        return self.f1.oblicz(zmienne) == self.f2.oblicz(zmienne)

    def __str__(self):
        return f'{self.f1.__str__()} <=> {self.f2.__str__()}'


test1 = Alternatywa(
    Zmienna('x'),
    Negacja(Zmienna('x'))
)

test2 = Rownowaznosc(
    Negacja(
        Koniunkcja(
            Zmienna('p'),
            Zmienna('q')
        )
    ),
    Alternatywa(
        Negacja(
            Zmienna('a')
        ),
        Negacja(
            Zmienna('q')
        )
    )
)

print(test1)
print(test1.oblicz({'x': True}))
print(test2)
print(test2.tautologia())
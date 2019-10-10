class Formula:
    def __init__(self):
        pass

    def oblicz(self, zmienne=[]):
        pass

    def __str__(self):
        pass

class T(Formula):
    def __init__(self):
        super().__init__()

    def oblicz(self, zmienne=[]):
        return True

    def __str__(self):
        return 'T'

class F(Formula):
    def __init__(self):
        super().__init__()

    def oblicz(self, zmienne=[]):
        return False

    def __str__(self):
        return 'F'

class Zmienna(Formula):
    nazwa = ''

    def __init__(self, nazwa_zmiennej):
        self.nazwa = nazwa_zmiennej

    def oblicz(self, zmienne):
        for zm, war in zmienne:
            if self.nazwa == zm:
                return war
        return Exception('nie ma zmiennej')

    def __str__(self):
        return self.nazwa

class Negacja(Formula):
    formula = None

    def __init__(self, formula):
        self.formula = formula

    def oblicz(self, zmienne=[]):
        return not self.formula.oblicz(zmienne)

    def __str__(self):
        return f'(~{self.formula.__str__()})'

class Koniunkcja(Formula):
    f1 = None
    f2 = None

    def __init__(self, formula1, formula2):
        self.f1 = formula1
        self.f2 = formula2

    def oblicz(self, zmienne=[]):
        return self.f1.oblicz(zmienne) and self.f2.oblicz(zmienne)

    def __str__(self):
        return f'({self.f1.__str__()} and {self.f2.__str__()})'

class Alternatywa(Formula):
    f1 = None
    f2 = None

    def __init__(self, formula1, formula2):
        self.f1 = formula1
        self.f2 = formula2

    def oblicz(self, zmienne=[]):
        return self.f1.oblicz(zmienne) or self.f2.oblicz(zmienne)

    def __str__(self):
        return f'({self.f1.__str__()} or {self.f2.__str__()})'

class Implikacja(Formula):
    f1 = None
    f2 = None

    def __init__(self, formula1, formula2):
        self.f1 = formula1
        self.f2 = formula2

    def oblicz(self, zmienne=[]):
        return not(self.f1.oblicz(zmienne)) or self.f2.oblicz(zmienne)

    def __str__(self):
        return f'({self.f1.__str__()} => {self.f2.__str__()})'

class Rownowaznosc(Formula):
    f1 = None
    f2 = None

    def __init__(self, formula1, formula2):
        self.f1 = formula1
        self.f2 = formula2

    def oblicz(self, zmienne=[]):
        return self.f1.oblicz(zmienne) == self.f2.oblicz(zmienne)

    def __str__(self):
        return f'({self.f1.__str__()} <=> {self.f2.__str__()})'



print(
    Implikacja(
        Zmienna('x'),
        F()
    ).oblicz([('x', 1)])
)

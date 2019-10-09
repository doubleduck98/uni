import wyrazenie

class stala:
    value = 0.0

    def __init__(self, value):
        self.value = value

    def oblicz(self, zmienne):
        return self.value

    def __str__(self):
        return ' ' +self.value +' '
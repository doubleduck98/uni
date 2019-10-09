import wyrazenie

class razy:
    expr1 = None
    expr2 = None

    def __init__(self, e1, e2):
        self.expr1 = e1
        self.expr2 = e2
    
    def oblicz(self, zmienne):
        return self.expr1.oblicz(zmienne) * self.expr2.oblicz(zmienne)

    def __str__(self):
        return '(' +self.expr1.__str__ +' * ' +self.expr2.__str__ +')'
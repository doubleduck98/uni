import wyrazenie

class zmienna():
    tag = ""

    def __init__(self, name):
        super(self)
        self.tag = name

    def oblicz(self, variables):
        for tag, val in variables:
            if tag == self.tag: return val
            else: return "error"

    def __str__(self):
        return self.tag

zakupy = [0.2, 0.5, 4.59, 6]

def vat_faktura(lista):
    suma = .23 * sum(lista)
    print(suma) 
    return suma

def vat_paragon(lista):
    suma = 0.0
    for x in lista:
        suma += .23 * x
    print(suma)
    return suma

print(vat_faktura(zakupy) == vat_paragon(zakupy))

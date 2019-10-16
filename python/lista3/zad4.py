def upieknij(lista_slow):
    prev = '.'
    nowa_lista_slow = []
    for slw in lista_slow:
        if any(znak for znak in ['?', '.', '!'] if prev.endswith(znak)):
            nowa_lista_slow.append(slw.capitalize())
        else:
            nowa_lista_slow.append(slw)
        prev = slw
    if nowa_lista_slow[-1].endswith(','):
        nowa_lista_slow[-1] = nowa_lista_slow[-1][:-1]
    return nowa_lista_slow


def uprosc_zdanie(tekst, dl_slowa, liczba_slow):
    slowa = tekst.split()
    skrocone_slowa = [slw.lower() for slw in slowa if len(slw) <= dl_slowa]
    skrocone_slowa = skrocone_slowa[:liczba_slow]
    skrocone_slowa = upieknij(skrocone_slowa)
    return ' '.join(skrocone_slowa).__add__('.')


text = open("pantadeusz.txt", "r")
print(uprosc_zdanie(text.read(), 7, 160))

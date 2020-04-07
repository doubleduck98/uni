from collections import deque

labirynt = list()
cele = set()
lista_ruchow = ['L', 'D', 'U', 'R']


class stan:
    def __init__(self, lista_komandosow=None, kroki=None):
        self.komandosi = lista_komandosow or set()
        self.kroki = kroki or ''


# cele i pozycje startowe komandosów
def init():
    init_stan = stan()

    for i in range(len(labirynt)):
        for j in range(len(labirynt[i])):
            if labirynt[i][j] == 'S':
                init_stan.komandosi.add((i, j))
                labirynt[i][j] = ' '
            elif labirynt[i][j] == 'G':
                cele.add((i, j))
                labirynt[i][j] = ' '
            elif labirynt[i][j] == 'B':
                init_stan.komandosi.add((i, j))
                cele.add((i, j))
                labirynt[i][j] = ' '

    return init_stan


# wykonaj jeden podany ruch
def ruch(k, r):
    if r == 'L':
        if labirynt[k[0]][k[1] - 1] != '#':
            return k[0], k[1] - 1
    elif r == 'R':
        if labirynt[k[0]][k[1] + 1] != '#':
            return k[0], k[1] + 1
    elif r == 'U':
        if labirynt[k[0] - 1][k[1]] != '#':
            return k[0] - 1, k[1]
    elif r == 'D':
        if labirynt[k[0] + 1][k[1]] != '#':
            return k[0] + 1, k[1]
    return k[0], k[1]


# wykonaj ruch dla kazdego komandosa, zwroc nowy stan
def ruchy(st, r):
    nst = stan()
    for komandos in st.komandosi:
        nst.komandosi.add(ruch(komandos, r))
    nst.kroki = st.kroki + r
    return nst


# sprawdzam czy dany stan osiągnął cel
def koniec(st):
    return all(komandos in cele for komandos in st.komandosi)


# losowe ruchy dla wszystkich komandosów
def faza_pierwsza(st):
    nst = stan(st.komandosi, st.kroki)
    ver = len(labirynt[0])
    hor = len(labirynt)

    for _ in range(hor):
        nst = ruchy(nst, 'D')
    for _ in range(ver):
        nst = ruchy(nst, 'L')

    return nst


def faza_druga(st):
    q = deque()
    q.append(st)
    visited = set()

    # jeżeli dwoch komandosów stoi na jednym miejscu, to liczymy go jako jednego
    min_liczba_komandosow = len(st.komandosi)

    while len(q) > 0:
        ob_stan = q.popleft()

        if len(ob_stan.kroki) > 150:
            continue

        if tuple(ob_stan.komandosi) in visited:
            continue
        visited.add(tuple(ob_stan.komandosi))

        if koniec(ob_stan):
            return ob_stan.kroki

        nastepne_ruchy = list()
        for r in lista_ruchow:
            ns = ruchy(ob_stan, r)
            nastepne_ruchy.append(ns)
            if len(ns.komandosi) < min_liczba_komandosow:
                min_liczba_komandosow = len(ns.komandosi)
                q.clear()
                visited.clear()

        for nr in nastepne_ruchy:
            if len(nr.komandosi) <= min_liczba_komandosow:
                q.append(nr)


if __name__ == '__main__':

    with open('./zad_input.txt') as inp:
        for linijka in inp:
            l = list()
            for ch in linijka:
                if ch != '\n':
                    l.append(ch)
            labirynt.append(l)

    st = init()
    st = faza_pierwsza(st)
    zwycieski_plan = faza_druga(st)
    print(zwycieski_plan)

    res = open('./zad_output.txt', 'w')
    res.write(zwycieski_plan)
    res.close()

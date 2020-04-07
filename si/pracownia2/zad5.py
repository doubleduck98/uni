import sys
import heapq as hq

labirynt = list()
odleglosci = list()
cele = set()
lista_ruchow = ['L', 'D', 'U', 'R']


class stan:
    def __init__(self, lista_komandosow=None, kroki=None):
        self.komandosi = lista_komandosow or set()
        self.kroki = kroki or ''

    def __lt__(self, other):
        return len(self.kroki) < len(other.kroki)


# odległości taksówkowe od najbliższego celu
def init_odl():

    def dj(xy):
        q = []
        visited = set()
        visited.add(xy)
        hq.heappush(q, (0, xy))

        while q:
            odl, curr_xy = hq.heappop(q)
            x, y = curr_xy[0], curr_xy[1]

            if curr_xy in cele:
                return odl

            nxys = [(x+1, y), (x-1, y), (x, y+1), (x, y-1)]

            for nxy in nxys:
                if nxy not in visited and labirynt[nxy[0]][nxy[1]] != '#':
                    visited.add(nxy)
                    hq.heappush(q, (odl+1, nxy))

    for i in range(len(odleglosci)):
        for j in range(len(odleglosci[i])):
            if odleglosci[i][j] != '#':
                odleglosci[i][j] = dj((i, j))


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


def znajdz_ruchy(st):
    # heurystyka
    def heura(st):
        return len(st.kroki) + max([(odleglosci[x][y]) for x, y in st.komandosi])

    q = []
    hq.heappush(q, (heura(st), [st]))
    visited = set()

    while len(q) > 0:
        _, ob_stan_l = hq.heappop(q)
        ob_stan = ob_stan_l[0]

        if len(ob_stan.kroki) > 150:
            continue

        if tuple(ob_stan.komandosi) in visited:
            continue
        visited.add(tuple(ob_stan.komandosi))

        if koniec(ob_stan):
            return ob_stan.kroki

        for r in lista_ruchow:
            ns = ruchy(ob_stan, r)
            hq.heappush(q, (heura(ns), [ns]))


if __name__ == '__main__':

    with open('./zad_input.txt') as inp:
        for linijka in inp:
            l = list()
            for ch in linijka:
                if ch != '\n':
                    l.append(ch)
            labirynt.append(l)

    st = init()

    odleglosci = labirynt.copy()
    init_odl()
    # for o in odleglosci:
    #     print(*o)

    k = znajdz_ruchy(st)
    print(k)

    res = open('./zad_output.txt', 'w')
    res.write(k)
    res.close()

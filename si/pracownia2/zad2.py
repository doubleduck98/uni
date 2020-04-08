import heapq as hq
from collections import deque

KOLUMNY, WIERSZE = 0, 0
plansza = list()
cele = set()
lista_ruchow = ['L', 'D', 'U', 'R']


class stan:
    def __init__(self, magazynier=None, skrzynki=None, kroki=None):
        self.magazynier = magazynier or (0, 0)
        self.skrzynki = skrzynki or set()
        self.kroki = kroki or ''

    def __lt__(self, other):
        return len(self.kroki) < len(other.kroki)


# inicjalizacja, zwracam stan początkowy
def init():
    global WIERSZE, KOLUMNY
    st = stan()

    for i in range(len(plansza)):
        for j in range(len(plansza[i])):
            if plansza[i][j] == 'K':
                st.magazynier = (i, j)
            elif plansza[i][j] == 'B':
                st.skrzynki.add((i, j))
            elif plansza[i][j] == 'G':
                cele.add((i, j))
            elif plansza[i][j] == '*':
                cele.add((i, j))
                st.skrzynki.add((i, j))
            elif plansza[i][j] == '+':
                cele.add((i, j))
                st.magazynier = (i, j)

    WIERSZE = len(plansza)
    KOLUMNY = len(plansza[0])

    return st


# zwraca t/f gdy xy jest na planszy, nie jest scianą albo jest puste
def wolne_pole(st, xy):
    return 0 <= xy[0] <= WIERSZE-1 and 0 <= xy[1] <= KOLUMNY-1 and plansza[xy[0]][xy[1]] != 'W' and (xy[0], xy[1]) not in st.skrzynki


# rusz magazynierem, zwróć nowy stan
def ruch(st, r):
    ns = stan()
    ns.kroki = st.kroki + r
    x, y = st.magazynier[0], st.magazynier[1]

    if r == 'L':
        if wolne_pole(st, (x, y-1)):
            ns.magazynier = (x, y-1)
            ns.skrzynki = st.skrzynki.copy()
            return ns
        # może przesuwamy skrzynke
        elif (x, y-1) in st.skrzynki:
            if wolne_pole(st, (x, y-2)):
                ns.magazynier = (x, y-1)
                ns.skrzynki = st.skrzynki.copy()
                ns.skrzynki.remove((x, y-1))
                ns.skrzynki.add((x, y-2))
                return ns

    elif r == 'R':
        if wolne_pole(st, (x, y+1)):
            ns.magazynier = (x, y+1)
            ns.skrzynki = st.skrzynki.copy()
            return ns
        elif (x, y+1) in st.skrzynki:
            if wolne_pole(st, (x, y+2)):
                ns.magazynier = (x, y+1)
                ns.skrzynki = st.skrzynki.copy()
                ns.skrzynki.remove((x, y+1))
                ns.skrzynki.add((x, y+2))
                return ns

    elif r == 'U':
        if wolne_pole(st, (x-1, y)):
            ns.magazynier = (x-1, y)
            ns.skrzynki = st.skrzynki
            return ns
        elif (x-1, y) in st.skrzynki:
            if wolne_pole(st, (x-2, y)):
                ns.magazynier = (x-1, y)
                ns.skrzynki = st.skrzynki.copy()
                ns.skrzynki.remove((x-1, y))
                ns.skrzynki.add((x-2, y))
                return ns

    elif r == 'D':
        if wolne_pole(st, (x+1, y)):
            ns.magazynier = (x+1, y)
            ns.skrzynki = st.skrzynki
            return ns
        elif (x+1, y) in st.skrzynki:
            if wolne_pole(st, (x+2, y)):
                ns.magazynier = (x+1, y)
                ns.skrzynki = st.skrzynki.copy()
                ns.skrzynki.remove((x+1, y))
                ns.skrzynki.add((x+2, y))
                return ns

    return None


# sprawdzam czy każda skrzynka dotarła do celu
def koniec(st):
    return all(sk in cele for sk in st.skrzynki)


# głowny program, wersja bfs
def sokoban_bfs(st):
    q = deque()
    visited = set()

    q.append(st)

    while len(q) > 0:
        ob_stan = q.popleft()

        stan_id = ((ob_stan.magazynier), tuple(ob_stan.skrzynki))
        if stan_id in visited:
            continue
        visited.add(stan_id)

        if koniec(ob_stan):
            return ob_stan.kroki

        for r in lista_ruchow:
            nr = ruch(ob_stan, r)
            if nr is not None:
                q.append(nr)


# głowny program, wersja A*
def sokoban_ast(st):

    def heura(st):
        x, y = st.magazynier[0], st.magazynier[1]
        # bierzemy odległość danej skrzynki od najbliższego celu
        skrz = []
        for s in st.skrzynki:
            odl = min(abs(s[0] - c[0]) + abs(s[1] - c[1]) for c in cele)
            skrz.append((s, odl))
        # liczba kroków + magazynier->skrzynka + skrzynka->cel
        return len(st.kroki) + min(abs(x - sx) + abs(y - sy) + so for (sx, sy), so in skrz)

    q = []
    hq.heappush(q, (heura(st), [st]))
    visited = set()

    while len(q) > 0:
        _, ob_stan_l = hq.heappop(q)
        ob_stan = ob_stan_l[0]

        stan_id = ((ob_stan.magazynier), tuple(ob_stan.skrzynki))
        if stan_id in visited:
            continue
        visited.add(stan_id)

        if koniec(ob_stan):
            return ob_stan.kroki

        for r in lista_ruchow:
            nr = ruch(ob_stan, r)
            if nr is not None:
                hq.heappush(q, (heura(nr), [nr]))


if __name__ == '__main__':

    with open('./zad_input.txt') as inp:
        for linijka in inp:
            l = list()
            for ch in linijka:
                if ch != '\n':
                    l.append(ch)
            plansza.append(l)

    st = init()
    # res = sokoban_bfs(st)
    res = sokoban_ast(st)

    print(len(res))
    with open('zad_output.txt', 'w') as out:
        out.write(res)

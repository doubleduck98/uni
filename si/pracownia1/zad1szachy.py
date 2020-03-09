import argparse
from collections import deque


class szachownica:
    def __init__(self, stan, prev=None):
        self.ruch = stan[0]
        self.bialy_k = stan[1]
        self.biala_w = stan[2]
        self.czarny_k = stan[3]
        self.kroki = stan[4]
        self.poprzedni_ruch = prev

    # debug
    def __str__(self):
        return f'{self.kroki}\u00B0 {para_do_pozycji(self.bialy_k)} {para_do_pozycji(self.biala_w)} {para_do_pozycji(self.czarny_k)}'

    def format(self):
        return [str(self.kroki) + '\u00B0',
                para_do_pozycji(self.bialy_k),
                para_do_pozycji(self.biala_w),
                para_do_pozycji(self.czarny_k)]


def pozycja_do_pary(pos):
    return ord(pos[0]) - ord('a') + 1, int(pos[1])


def para_do_pozycji(para):
    c = chr(para[0] + ord('a') - 1)
    return f'{c}{para[1]}'


# ruchy to kolejne możliwe stany
# wektory ruchow dla krolow
kx = [-1, 0, 1, -1, 1, -1, 0, 1]
ky = [1, 1, 1, 0, 0, -1, -1, -1]


# ruchy czarnego krola
def ruchy_cz_k(st):
    nast_ruchy = set()

    # 8 ruchow dookoła
    for i in range(8):
        x, y = st.czarny_k[0] + kx[i], st.czarny_k[1] + ky[i]
        # jezeli da sie ruszyc to dodaje nowy ruch do zbioru
        if 1 <= x <= 8 and 1 <= y <= 8:
            if abs(x - st.bialy_k[0]) > 1 or abs(y - st.bialy_k[1]) > 1:
                # teraz wieża, chce sprawdzic czy bialy krol nie zasłania
                # sa w roznych wierszach/kolumnach
                if st.biala_w[0] != st.bialy_k[0] and st.biala_w[1] != st.bialy_k[1]:
                    if x != st.biala_w[0] and y != st.biala_w[1]:
                        nast_ruchy.add(szachownica(
                            ('white', st.bialy_k, st.biala_w, (x, y), st.kroki + 1)))
                else:
                    # zasłania w pionie
                    if st.biala_w[0] == st.bialy_k[0] and (y > st.bialy_k[1] > st.biala_w[1] or y < st.bialy_k[1] < st.biala_w[1]):
                        nast_ruchy.add(szachownica(
                            ('white', st.bialy_k, st.biala_w, (x, y), st.kroki + 1)))
                    # zasłania a poziomie
                    elif st.biala_w[1] == st.bialy_k[1] and (x > st.bialy_k[0] > st.biala_w[0] or x < st.bialy_k[0] < st.biala_w[0]):
                        nast_ruchy.add(szachownica(
                            ('white', st.bialy_k, st.biala_w, (x, y), st.kroki + 1)))
                    # nie zaslania
                    elif x != st.biala_w[0] and y != st.biala_w[1]:
                        nast_ruchy.add(szachownica(
                            ('white', st.bialy_k, st.biala_w, (x, y), st.kroki + 1)))

    return nast_ruchy


# ruchy bialego krola
def ruchy_b_k(st):
    nast_ruchy = set()

    for i in range(8):
        x, y = st.bialy_k[0] + kx[i], st.bialy_k[1] + ky[i]
        if 1 <= x <= 8 and 1 <= y <= 8:
            if x != st.biala_w[0] or y != st.biala_w[1]:
                if abs(x - st.czarny_k[0]) > 1 or abs(y - st.czarny_k[1]) > 1:
                    nast_ruchy.add(szachownica(
                        ('black', (x, y), st.biala_w, st.czarny_k, st.kroki + 1)))

    return nast_ruchy


# ruchy bialej wiezy
def ruchy_b_w(st):
    nast_ruchy = set()

    # chyba nie mozna stac w jednym rzedzie/kolumnie z czarnym krolem
    # tylko kolizje z bialym
    x, y = st.biala_w[0], st.biala_w[1]
    if st.biala_w[0] == st.bialy_k[0]:
        # jezeli sa w tej samej kolumnie to dodajemy caly rzad
        for nx in range(1, 9):
            if nx == x:
                continue
            nast_ruchy.add(szachownica(
                ('black', st.bialy_k, (nx, y), st.czarny_k, st.kroki + 1)))

        # a tutaj bierzemy pod uwage blokade
        od, do = 1, 9
        if y > st.bialy_k[1]:
            od = st.bialy_k[1] + 1
        else:
            do = st.bialy_k[1]
        for ny in range(od, do):
            if ny == y:
                continue
            nast_ruchy.add(szachownica(
                ('black', st.bialy_k, (x, ny), st.czarny_k, st.kroki + 1)))

    elif st.biala_w[1] == st.bialy_k[1]:
        # analogicznie, tylko teraz są w tej samej kolumnie
        od, do = 1, 9
        if x > st.bialy_k[0]:
            od = st.bialy_k[0] + 1
        else:
            do = st.bialy_k[0]
        for nx in range(od, do):
            if nx == x:
                continue
            nast_ruchy.add(szachownica(
                ('black', st.bialy_k, (nx, y), st.czarny_k, st.kroki + 1)))

        for ny in range(1, 9):
            if ny == y:
                continue
            nast_ruchy.add(szachownica(
                ('black', st.bialy_k, (x, ny), st.czarny_k, st.kroki + 1)))

    elif st.biala_w[0] != st.bialy_k[0] and st.biala_w[1] != st.bialy_k[1]:
        for nx in range(1, 9):
            if nx == x:
                continue
            nast_ruchy.add(szachownica(
                ('black', st.bialy_k, (nx, y), st.czarny_k, st.kroki + 1)))
        for ny in range(1, 9):
            if ny == y:
                continue
            nast_ruchy.add(szachownica(
                ('black', st.bialy_k, (x, ny), st.czarny_k, st.kroki + 1)))

    return nast_ruchy


# ruchy bialych figur
def ruchy_b(st):
    return ruchy_b_k(st) | ruchy_b_w(st)


# niepełny
def szachmat(st):
    ckx, cky = st.czarny_k[0], st.czarny_k[1]
    bwx, bwy = st.biala_w[0], st.biala_w[1]

    # czarny krol i biala wieza są w tej samej kolumnie/wierszu
    # i czarny krol nie moze zbic
    return (ckx == bwx and abs(cky - bwy) > 1) or (cky == bwy and abs(ckx - bwx) > 1)


def partia(pocz):
    rozwazane_ruchy = set()
    kolejka = deque()
    kolejka.append(pocz)

    while(len(kolejka) > 0):
        stan = kolejka.popleft()
        stan_id = (stan.bialy_k, stan.biala_w, stan.czarny_k)

        if stan_id in rozwazane_ruchy:
            continue

        # jak czarny krol nie ma ruchow to jest potencjalny szach-mat
        rck = ruchy_cz_k(stan)
        if len(rck) == 0 and stan.ruch == 'black':
            if szachmat(stan):
                if DEBUG:
                    return stan
                return stan.kroki
            else:
                # jak nie ma ruchow i to nie szachmat to nie rozwazamy dalej
                continue

        nastepne_ruchy = set()
        if stan.ruch == 'white':
            nastepne_ruchy = ruchy_b(stan)
        else:
            nastepne_ruchy = rck
        for ruch in nastepne_ruchy:
            if DEBUG:
                ruch.poprzedni_ruch = stan
            kolejka.append(ruch)
        rozwazane_ruchy.add(stan_id)


def pierwszy_ruch(line):
    spl = line.split()
    krotka = (spl[0], pozycja_do_pary(spl[1]),
              pozycja_do_pary(spl[2]), pozycja_do_pary(spl[3]), 0)
    return szachownica(krotka)


def ladnie_wypisz(res):
    res.append(['No.', 'BK', 'BW', 'CK'])
    szer = len(res[-2][1]) + 1
    for res in reversed(res):
        for st in res:
            print(st.rjust(szer), end='')
        print()


DEBUG = False

if __name__ == '__main__':
    def get_argparser():
        parser = argparse.ArgumentParser()
        parser.add_argument('--infile', default='zad1_input.txt',
                            type=argparse.FileType('r', encoding='UTF-8'), help='Plik z danymi')
        return parser

    parser = get_argparser()
    args = parser.parse_args()

    if not DEBUG:
        plik_wyn = open('zad1_output.txt', 'w')

    with open(args.infile.name) as plik:
        for line in plik:
            r1 = pierwszy_ruch(line)
            if DEBUG:
                res = partia(r1)
                res_list = []
                while res is not None:
                    res_list.append(res.format())
                    res = res.poprzedni_ruch
                ladnie_wypisz(res_list)
            else:
                plik_wyn.write(str(partia(r1)))
    
    if not DEBUG:
        plik_wyn.close()

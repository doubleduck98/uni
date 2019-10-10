def tabliczka(x1, x2, y1, y2):
    if x1 > x2:
        x1, x2 = x2, x1
    if y1 > y2:
        y1, y2 = y2, y1
    xy = [[] for i in range(y2-y1+2)]
    xy[0].append('\\')
    for x in range (x1, x2+1):
        xy[0].append(x)
    a = 1
    for y in range(y1, y2+1):
        xy[a].append(y)
        for x in range (x1, x2+1):
            xy[a].append(x*y)
        a += 1
    szer = max(len(str(licz)) for rzad in xy for licz in rzad) + 2
    for rzad in xy:
        print(''.join(str(licz).rjust(szer) for licz in rzad))




liczby = (input("Podaj 4 liczby: ").split())
tabliczka(int(liczby[0]), int(liczby[1]), int(liczby[2]), int(liczby[3]))
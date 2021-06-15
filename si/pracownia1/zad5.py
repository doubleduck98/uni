import random


def opt_dist(list, D):
    # tablica sum prefiksowych
    pref = [0 for _ in range(len(list) + 1)]
    for i in range(1, len(list) + 1):
        pref[i] = pref[i-1] + list[i-1]

    res = len(list)
    # przechodzimy po kolei okienkiem długości D
    for i in range(len(list) - D + 1):
        end = i + D - 1
        curr = pref[end+1] - pref[i]
        before = pref[i]
        after = pref[len(list)] - pref[end+1]
        res = min(res, D - curr + before + after)
    return res


def is_valid(row, val):
    cnt = 0
    for i in range(len(row)):
        if row[i] == 1:
            if cnt > 0 and row[i-1] == 0:
                return False
            cnt += 1
    return cnt == val


def is_completed(rows, cols):
    for i in range(height):
        if not is_valid(rows[i], specs[0][i]):
            return False
    for j in range(width):
        if not is_valid(cols[j], specs[1][j]):
            return False
    return True


def swap(i, j, rows, cols):
    rows[i][j] = 1 - rows[i][j]
    cols[j][i] = 1 - cols[j][i]


def printer(rows):
    res = ''
    for r in rows:
        for x in r:
            if x == 0:
                print('.', end='')
                res += '.'
            elif x == 1:
                print('#', end='')
                res += '#'
        res += '\n'
        print()
    return res


def try_position(rows, cols):
    maxVal, maxInd = -1, -1
    pick = random.randint(0, 1)
    if pick:
        c = random.randint(0, height-1)
        for r in range(width):
            before = opt_dist(cols[r], specs[1][r]) + \
                opt_dist(rows[c], specs[0][c])
            swap(c, r, rows, cols)
            after = opt_dist(cols[r], specs[1][r]) + \
                opt_dist(rows[c], specs[0][c])
            if before - after > maxVal:
                maxVal = before - after
                maxInd = r
            swap(c, r, rows, cols)
        swap(c, maxInd, rows, cols)
    else:
        c = random.randint(0, width-1)
        for r in range(height):
            before = opt_dist(cols[c], specs[1][c]) + \
                opt_dist(rows[r], specs[0][r])
            swap(r, c, rows, cols)
            after = opt_dist(cols[c], specs[1][c]) + \
                opt_dist(rows[r], specs[0][r])
            if before - after > maxVal:
                maxVal = before - after
                maxInd = r
            swap(r, c, rows, cols)
        swap(maxInd, c, rows, cols)


def reset():
    rows = [[0 for _ in range(width)] for _ in range(height)]
    cols = [[0 for _ in range(width)] for _ in range(height)]
    return rows, cols


def solve():
    rows, cols = reset()
    i = 0
    while True:
        try_position(rows, cols)
        if is_completed(rows, cols):
            res = printer(rows)
            print(i)
            return res
        if i == 499:
            rows, cols = reset()
            i = 0
        i += 1


height, width = 0, 0
specs = tuple()
with open('zad5_input.txt', 'r') as inp:
    rows, cols = [], []
    dimensions = inp.readline().strip('\n').split(' ')
    height, width = int(dimensions[0]), int(dimensions[1])
    for _ in range(height):
        rows.append(int(inp.readline().rstrip('\n')))
    for _ in range(width):
        cols.append(int(inp.readline().rstrip('\n')))
    specs = (rows, cols)
res = open('zad5_output.txt', 'w')
res.write(solve())
res.close()

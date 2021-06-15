import random
from datetime import datetime

INF = 1**9
M = 8
BOT, AGENT = 0, 1

corners = {(0, 0), (0, 7), (7, 0), (7, 7)}

weights = [[10, 0, 4, 2, 2, 4, 0, 10],
           [0, 0, 4, 2, 2, 4, 0, 0],
           [4, 4, 4, 2, 2, 4, 4, 4],
           [2, 2, 2, 0, 0, 2, 2, 2],
           [2, 2, 2, 0, 0, 2, 2, 2],
           [4, 4, 4, 2, 2, 4, 4, 4],
           [0, 0, 4, 2, 2, 4, 0, 0],
           [10, 0, 4, 2, 2, 4, 0, 10]]


def initial_board():
    B = [[None] * M for _ in range(M)]
    B[3][3] = 1
    B[4][4] = 1
    B[3][4] = 0
    B[4][3] = 0
    return B


def cp(b):
    nb = Board()
    nb.board = [list(row) for row in b.board]
    nb.fields = set(b.fields)
    nb.move_list = list(b.move_list)
    nb.history = list(b.history)
    return nb


class Board:
    dirs = [(0, 1), (1, 0), (-1, 0), (0, -1),
            (1, 1), (-1, -1), (1, -1), (-1, 1)]

    def __init__(self):
        self.board = initial_board()
        self.fields = set()
        self.move_list = []
        self.history = []
        for i in range(M):
            for j in range(M):
                if self.board[i][j] == None:
                    self.fields.add((j, i))

    def moves(self, player):
        res = []
        for (x, y) in self.fields:
            if any(self.can_beat(x, y, direction, player) for direction in Board.dirs):
                res.append((x, y))
        if not res:
            return [None]
        return res

    def can_beat(self, x, y, d, player):
        dx, dy = d
        x += dx
        y += dy
        cnt = 0
        while self.get(x, y) == 1-player:
            x += dx
            y += dy
            cnt += 1
        return cnt > 0 and self.get(x, y) == player

    def get(self, x, y):
        if 0 <= x < M and 0 <= y < M:
            return self.board[y][x]
        return None

    def do_move(self, move, player):
        self.history.append([x[:] for x in self.board])
        self.move_list.append(move)

        if move == None:
            return
        x, y = move
        x0, y0 = move
        self.board[y][x] = player
        self.fields -= set([move])
        for dx, dy in self.dirs:
            x, y = x0, y0
            to_beat = []
            x += dx
            y += dy
            while self.get(x, y) == 1-player:
                to_beat.append((x, y))
                x += dx
                y += dy
            if self.get(x, y) == player:
                for (nx, ny) in to_beat:
                    self.board[ny][nx] = player

    def result(self):
        res = 0
        for y in range(M):
            for x in range(M):
                b = self.board[y][x]
                if b == 0:
                    res -= 1
                elif b == 1:
                    res += 1
        return res

    def terminal(self):
        if not self.fields:
            return True
        if len(self.move_list) < 2:
            return False
        return self.move_list[-1] == self.move_list[-2] == None

    def random_move(self, player):
        ms = self.moves(player)
        if ms:
            return random.choice(ms)
        return [None]

    def next_move_mcts(self, player):
        start = datetime.now()
        moves = self.moves(player)
        if any(move in corners for move in self.moves(player)):
            return random.choice(list(corners & set(moves)))

        mm = max(moves, key=lambda move: self.sim_n_games(
            10, move, player))
        print(f'{datetime.now()-start}')
        return mm

    def sim_n_games(self, n_games, first_move, player):
        result = 0
        sim = cp(self)
        sim.do_move(first_move, player)
        for _ in range(n_games):
            _sim = cp(sim)
            _player = 1 - player

            while(True):
                m = _sim.random_move(_player)
                _sim.do_move(m, _player)
                _player = 1 - _player
                if _sim.terminal():
                    break
            result += _sim.result() > 0
        return result


def mcts_agent_move(B):
    m = B.next_move_mcts(AGENT)
    B.do_move(m, AGENT)


if __name__ == "__main__":
    defeats = 0
    n_games = 10
    start = datetime.now()
    for i in range(n_games):
        B = Board()
        player = i % 2
        while True:
            if player == AGENT:
                # random_agent_move(B)
                mcts_agent_move(B)
            else:
                m = B.random_move(player)
                B.do_move(m, player)
            if B.terminal():
                break
            player = 1 - player
        res = B.result()
        print(res)
        if res < 0:
            defeats += 1
    print(f'{defeats}/{n_games}')
    print(f'{datetime.now()-start}')

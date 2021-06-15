import random
from datetime import datetime

INF = 1e9
M = 8
DEPTH = 0
BOT, AGENT = 0, 1

corners = {(0, 0), (0, 7), (7, 0), (7, 7)}

weights = [[10, -1, 3, 3, 3, 3, -1, 10],
           [-1, -1, 2, 2, 2, 2, -1, -1],
           [3, 2, 1, 1, 1, 1, 2, 3],
           [3, 2, 1, 0, 0, 1, 2, 3],
           [3, 2, 1, 0, 0, 1, 2, 3],
           [3, 2, 1, 1, 1, 1, 2, 3],
           [-1, -1, 2, 2, 2, 2, -1, -1],
           [10, -1, 3, 3, 3, 3, -1, 10]]


def initial_board():
    B = [[None] * M for _ in range(M)]
    B[3][3] = 1
    B[4][4] = 1
    B[3][4] = 0
    B[4][3] = 0
    return B


def cp(board):
    res = Board()
    res.board = []
    for row in board.board:
        res.board.append(row.copy())
    res.fields = board.fields.copy()
    return res


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

    def heura(self):
        def corners_caped():
            agent = 0
            for x, y in corners:
                b = self.board[y][x]
                if b == 1:
                    agent += 1
            return agent

        def weights_sum():
            agent = 0
            for y in range(M):
                for x in range(M):
                    b = self.board[y][x]
                    if b == 1:
                        agent += weights[y][x]
            return agent

        def n_diff():
            agent, bot = 0, 0
            for y in range(M):
                for x in range(M):
                    b = self.board[y][x]
                    if b == 0:
                        bot += 1
                    elif b == 1:
                        agent += 1
            if agent + bot == 0:
                return 0
            return agent - bot

        def moves_diff():
            agent, bot = len(B.moves(AGENT)), len(B.moves(0))
            if agent + bot == 0:
                return 0
            return agent - bot

        if len(self.move_list) >= 30:
            return 2 * n_diff() + moves_diff()
        else:
            return weights_sum()

    def next_move_ab(self, player):
        def alpha_beta(state, depth, alpha, beta, player):
            if depth == 0 or state.terminal() or state.moves(player) == [None]:
                return state.heura()

            moves = state.moves(player)
            if player == AGENT:
                value = -INF
                for move in moves:
                    new_board = cp(state)
                    new_board.do_move(move, player)
                    value = max(value, alpha_beta(
                        new_board, depth-1, alpha, beta, BOT))
                    alpha = max(alpha, value)
                    if value >= beta:
                        return value
                return value
            else:
                value = INF
                for move in moves:
                    new_board = cp(state)
                    new_board.do_move(move, player)
                    value = min(value, alpha_beta(
                        new_board, depth-1, alpha, beta, AGENT))
                    beta = min(beta, value)
                    if value <= alpha:
                        return value
                return value

        moves = self.moves(player)
        if any(move in corners for move in self.moves(player)):
            return random.choice(list(corners & set(moves)))

        best_move = None
        best_score = -INF
        for move in moves:
            new_board = cp(self)
            new_board.do_move(move, player)
            val = alpha_beta(new_board, DEPTH, -INF, INF, player)
            if val > best_score:
                best_move = move
                best_score = val
        return best_move


def random_agent_move(B):
    m = B.random_move(AGENT)
    B.do_move(m, AGENT)


def alpha_beta_agent_move(B):
    m = B.next_move_ab(AGENT)
    B.do_move(m, AGENT)


if __name__ == "__main__":
    defeats = 0
    n_games = 1000
    start = datetime.now()
    for i in range(n_games):
        B = Board()
        player = i % 2
        while True:
            if player == AGENT:
                # random_agent_move(B)
                alpha_beta_agent_move(B)
            else:
                m = B.random_move(player)
                B.do_move(m, player)
            if B.terminal():
                break
            player = 1 - player
        res = B.result()
        print(res)
        if res < 0:
            # print(f'lost {i}')
            defeats += 1
    print(f'{defeats}/{n_games}')
    print(f'{datetime.now()-start}')

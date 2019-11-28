import matplotlib.pyplot as plt
import numpy as np
from matplotlib.animation import FuncAnimation
from enum import Enum
import matplotlib.colors

norm = matplotlib.colors.Normalize(-1, 1)
colors = [[norm(-1.0), "black"],
          [norm(-0.6), "red"],
          [norm(0.6), "red"],
          [norm(1.0), "white"]]

my_cmap = matplotlib.colors.LinearSegmentedColormap.from_list("", colors)


class Move(Enum):
    north = 1
    west = 2
    east = 3
    south = 4


# ustawiamy pole
rows, cols = 100, 100
grid = np.ones(rows*cols)
grid = grid.reshape((rows, cols))
x, y = rows // 2, cols // 2

# ustawiamy mrówke
grid[x][y] = 0
last = Move.north
current = 1  # stoimy na białym


fig = plt.figure(num='Mrówka Langtona')
im = plt.imshow(grid, norm=norm, cmap=my_cmap)
plt.xticks([])
plt.yticks([])


def ant_move(grid):

    def move_right():  # jestesmy na czarnym, ustawiamy na białe
        global x, y, last, rows, cols
        if last == Move.north:
            grid[x][y] = 1
            x = (x + 1) % rows
            curr = grid[x][y]
            grid[x][y] = 0
            last = Move.west
            return curr
        elif last == Move.west:
            grid[x][y] = 1
            y = (y - 1) % cols
            curr = grid[x][y]
            grid[x][y] = 0
            last = Move.south
            return curr
        elif last == Move.south:
            grid[x][y] = 1
            x = (x - 1) % rows
            curr = grid[x][y]
            grid[x][y] = 0
            last = Move.east
            return curr
        else:
            grid[x][y] = 1
            y = (y + 1) % cols
            curr = grid[x][y]
            grid[x][y] = 0
            last = Move.north
            return curr

    def move_left():  # jestesmy na białym, ustawiamy na czarne
        global x, y, last, rows, cols
        if last == Move.north:
            grid[x][y] = -1
            x = (x - 1) % rows
            curr = grid[x][y]
            grid[x][y] = 0
            last = Move.east
            return curr
        elif last == Move.west:
            grid[x][y] = -1
            y = (y + 1) % cols
            curr = grid[x][y]
            grid[x][y] = 0
            last = Move.north
            return curr
        elif last == Move.south:
            grid[x][y] = -1
            x = (x + 1) % rows
            curr = grid[x][y]
            grid[x][y] = 0
            last = Move.west
            return curr
        else:
            grid[x][y] = -1
            y = (y - 1) % cols
            curr = grid[x][y]
            grid[x][y] = 0
            last = Move.south
            return curr

    global x, y, current
    if current == 1:  # stoimy na białym polu
        current = move_left()
    else:
        current = move_right()
    return grid


def animate(nth_frame):
    new_grid = ant_move(im.get_array())
    im.set_array(new_grid)
    frame = plt.text(1, 4, f'step: {nth_frame}')
    return [im, frame]


anim = FuncAnimation(fig, animate, interval=10,
                     frames=12000, blit=True, repeat=False)
plt.show()

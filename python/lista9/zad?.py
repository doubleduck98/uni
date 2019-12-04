import matplotlib.image as mpimg
import matplotlib.pyplot as plt
import numpy as np
from PIL import Image


# pomysł:
#     iterujesz sie po kazdym pikselu: 
#         jezeli jest odpowiednio szary, to patrzysz naokoło jaki kolor boostujesz
#           SZUKASZ MAXA, OBNIZASZ INNE
#         jezeli w miare kolorowy to essa

im = Image.open('./lista9/xqc.png')
width, height = im.size #wielkość obrazka
print(f'{width} x {height}')
pixels = np.array(im)


for i in range(0, height):
    for j in range(0, width):
        pixel = im.getpixel((j, i))
        r, g, b, a = pixel[0], pixel[1], pixel[2], pixel[3]
        pixels[i][j] = (1, 1, 1, pixel[3])

im = Image.fromarray(pixels)
plt.imshow(im)
plt.axis('off')
plt.show()
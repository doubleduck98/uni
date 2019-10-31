set title "liczby pierwsze"
set terminal pngcairo size 1280,720 enhanced font 'Arial,14'

set ylabel "czas(s)"
set key right bottom

plot "plot.dat" using 1:2 with linespoints title "generator",\
    "plot.dat" using 1:3 with linespoints title "imperatywna",\
    "plot.dat" using 1:4 with linespoints title "skladana",\
    "plot.dat" using 1:5 with linespoints title "funkcyjna"

-- SZYMON ZIENKIEWICZ
-- ZADANIE 1
import           Data.List

lrepeat :: (Int -> Int) -> [a] -> [a]
lrepeat f lista = lrep (lista, 0, (f 0))
    where
        lrep(_:xs, i, 0) = lrep(xs, (i+1), f(i+1))
        lrep(x:xs, i, r) = x:lrep(x:xs, i, (r-1))
        lrep([], _, _)   = []

-- ZADANIE 2
sublist :: [Int] -> [a] -> [a]
sublist xs lst = sbl (lst, sort xs, 0)
    where
        sbl([], _, _) = []
        sbl(lst, [], _) = lst
        sbl(x:xs, h:t, indx) =
            if h == indx
                then sbl(xs, t, indx+1)
                else x:sbl(xs, h:t, indx+1)

-- ZADANIE 3
root3 :: Double -> Double
root3 a = rt a
    where
        rt x = if czydobra x
            then x
            else rt (x + (a / (x * x) - x) / 3.0)
        czydobra x = abs((x * x * x) - a) <= abs(a) * epsilon
        epsilon = 1e-15

test1 = root3 1
test2 = root3 0
test3 = root3 27
test4 = root3 (-27)

root3l :: Double -> Double
root3l a =
    if a == 0.0
        then 0.0
        else rt lista
    where
        rt l = if czydobra (take_next l)
            then (take_next l)
            else rt (Prelude.tail l)
        take_next l = Prelude.head (Prelude.tail l)
        czydobra x = abs((x * x * x) - a) <= abs(a) * epsilon
        epsilon = 1e-15
        lista = iterate (\x -> x + (a / (x * x) - x) / 3.0) a

test5 = root3l 1
test6 = root3l 0
test7 = root3l 27
test8 = root3l (-27)

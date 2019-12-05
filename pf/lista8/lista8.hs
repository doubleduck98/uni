-- SZYMON ZIENKIEWICZ
-- ZADANIE 1
import Data.List

lrepeat :: (Int -> Int) -> [a] -> [a]
lrepeat f lista = lrep (lista, 0, (f 0))
    where
        lrep(_:xs, i, 0) = lrep(xs, (i+1), f(i+1))
        lrep(x:xs, i, r) = x:lrep(x:xs, i, (r-1))
        lrep([], _, _) = []

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
--  SZYMON ZIENKIEWICZ
--  ZADANIE 1
import           Control.Monad.State

data Tree a = Leaf a | Branch (Tree a) (Tree a)
    deriving (Eq, Ord, Show, Read)

label :: Tree a -> Tree (a, Int)
label tree = fst (lbl tree 0) where
    lbl (Leaf a) n = (Leaf (a, n), n+1)
    lbl (Branch left right) n = (Branch leftsub rightsub, rightlabel) where
        (leftsub, leftlabel) = lbl left n
        (rightsub, rightlabel) = lbl right leftlabel

test = let t = Branch (Leaf 'a') (Leaf 'b')
    in label (Branch t t)

-- ZADANIE 2
next :: State Int Int
next = state $ \i -> (i, i+1)

mlabel :: Tree a -> Tree (a, Int)
mlabel tree = fst (mlbl tree 0) where
    mlbl (Leaf a) st = (Leaf (a, (evalState next st)), execState next st)
    mlbl (Branch left right) st = (Branch leftsub rightsub, rightlabel) where
        (leftsub, leftlabel) = mlbl left st
        (rightsub, rightlabel) = mlbl right leftlabel

test1 = let t = Branch (Leaf 'a') (Leaf 'b')
    in mlabel (Branch t t)

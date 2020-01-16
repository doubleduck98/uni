-- SZYMON ZIENKIEWICZ
import           Data.Functor
import           Data.Monoid

data MtreeL a = MTL a [MtreeL a]
 deriving (Eq, Ord, Show, Read)

mt1 = MTL 1 [MTL 2 [], MTL 3 [], MTL 4 []]
mt2 = MTL 5 [MTL 6 [], MTL 7 [MTL 11 [MTL 12 [], MTL 13 [], MTL 14 []]], MTL 8 []]
mt3 = MTL 10 [mt1, mt2]

-- ZADANIE 1
foldMtL :: Monoid a => MtreeL a -> a
foldMtL (MTL a [])     = a
foldMtL (MTL a (x:xs)) = foldMtL x <> foldMtL (MTL a xs)

mtl = MTL (Sum 1) [MTL (Sum 2) [], MTL (Sum 3) [], MTL (Sum 4) []]
mtl2 = MTL (Product 5) [MTL (Product 6) [], MTL (Product 7) [MTL (Product 11) [MTL (Product 12) [], MTL (Product 13) [], MTL (Product 14) []]], MTL (Product 8) []]

foldMtLMap :: Monoid a => (t -> a) -> MtreeL t -> a
foldMtLMap toMonoid (MTL a []) = toMonoid a
foldMtLMap toMonoid (MTL a (x:xs)) = foldMtLMap toMonoid x <> foldMtLMap toMonoid (MTL a xs)

test11 = getSum $ foldMtLMap Sum mt1
test12 = getProduct $ foldMtLMap Product mt2
test13 = getSum $ foldMtLMap Sum mt3

-- ZADANIE 2
instance Functor MtreeL where
    fmap f (MTL a xs) = MTL (f a) (ffmap f xs) where
        ffmap fun []     = []
        ffmap fun (x:xs) = (fmap fun x):(ffmap fun xs)

test2 =  ((+1) <$> mt1) == MTL 2 [MTL 3 [], MTL 4 [], MTL 5 []]

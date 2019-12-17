-- SZYMON ZIENKIEWICZ
-- ZADANIE 1
data Tree a = Leaf a | Node (Tree a) (Tree a)
    deriving (Eq, Ord, Show, Read)

isBalanced :: Tree a -> Bool
isBalanced (Leaf _) = True
isBalanced (Node l r) =
    abs((leafs l) - (leafs r)) <= 1
    && isBalanced l && isBalanced r
    where
        leafs (Leaf _)   =  1
        leafs (Node l r) = (leafs l) + (leafs r)

t1 = Node
    (Node (Leaf 1) (Leaf 1))
    (Node (Leaf 1) (Leaf 1))

t2 = Node
    (Node
        (Node (Leaf 2) (Leaf 2))
        (Leaf 1))
    (Leaf 0)

-- ZADANIE 3
data BTree a = BLeaf | BNode (BTree a) a (BTree a)
    deriving (Eq, Ord, Show, Read)

iLen :: BTree a -> Int
iLen a = sum a 0
    where
        sum BLeaf depth = 0
        sum (BNode l _ r) depth =
            depth
            + (sum l (depth + 1))
            + (sum r (depth + 1))

eLen :: BTree a -> Int
eLen a = sum a 0
    where
        sum BLeaf depth = depth
        sum (BNode l _ r) depth =
            (sum l (depth + 1)) + (sum r (depth + 1))

bt1 = BNode (BNode BLeaf 1 BLeaf) 0 (BNode BLeaf 1 BLeaf)
bt2 = BNode (BNode (BNode BLeaf 2 BLeaf) 1 (BNode BLeaf 2 BLeaf)) 0 (BNode BLeaf 1 BLeaf)

-- ZADANIE 4
data MtreeL a = MTL a [MtreeL a]
    deriving (Eq, Ord, Show, Read)


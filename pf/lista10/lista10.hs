-- SZYMON ZIENKIEWICZ
import           System.Random

randomInts :: Int -> (Int, Int) -> Int -> [Int]
randomInts n (lo, hi) zarodek = take n (randomRs (lo, hi) (mkStdGen zarodek))

randomIntIO :: (Int, Int) -> IO Int
randomIntIO (lo, hi) = randomRIO (lo, hi)

rowStr :: Int -> String
rowStr n = concat (replicate n "*")

printnim :: [Int] -> IO()
printnim nim = prnt nim 1 where
    prnt [] _ = putStrLn ""
    prnt (x:xs) rw = do
        putStr (show rw)
        putStr ": "
        putStrLn (rowStr x)
        prnt xs (rw + 1)

initnim :: Int -> [Int]
initnim n = randomInts n (1, n) 997211551354

finished :: [Int] -> Bool
finished = all (== 0)

valid :: [Int] -> Int -> Int -> Bool
valid board row num = (board !! (row-1) >= num) && num > 0

move :: [Int] -> Int -> Int -> [Int]
move board row num = mv board [] 1 where
    mv [] res _ = reverse res
    mv (x:xs) res n =
        if n == row
            then mv xs ((x - num):res) (n + 1)
            else mv xs (x:res) (n + 1)

game :: IO()
game = do
    putStr "podaj liczbe wierszy: "
    rows <- getLine
    let board = initnim (read rows)
    printnim board
    player board

player :: [Int] -> IO()
player board = do
    if finished board then putStrLn "wygrał komputer!"
    else do
        putStr "wybierz wiersz: "
        row <- getLine
        putStr "\n"
        putStr "wybierz liczbe gwiazdek: "
        num <- getLine
        putStr "\n"
        if valid board (read row) (read num)
            then do
                let newBoard = move board (read row) (read num)
                printnim newBoard
                comp newBoard
            else do
                putStrLn "nieprawidłowe dane"
                player board

comp :: [Int] -> IO()
comp board =
    let takeLast (x:xs) n = if x == 0
            then takeLast xs (n - 1)
            else n
    in if finished board then putStrLn "wygrałeś!"
    else do
        let row = takeLast (reverse board) (length board)
        let num = board !! (row - 1)
        putStrLn ("zabieram " ++ (show num) ++ " * z " ++ (show row) ++ " rzedu")
        let newBoard = move board row num
        printnim newBoard
        player newBoard

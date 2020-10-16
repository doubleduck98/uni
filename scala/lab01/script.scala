import scala.collection.mutable.ListBuffer
import scala.io.Source

import java.io.File

//scalar product of two vectors xs and ys
def scalarUgly(xs: List[Int], ys: List[Int]) = {
    if(xs.length < 1 || ys.length < 1)
        throw new Exception("lists have to have at least one element")
    else if (xs.length != ys.length)
        throw new Exception("given lists have to be of equal size")
    var product = 0
    var i = 0
    do {
        product += xs(i) * ys(i)
        i += 1
    } while (i < xs.length)
    product
}

def scalar(xs: List[Int], ys: List[Int]) = {
    if(xs.length < 1 || ys.length < 1)
        throw new Exception("lists have to have at least one element")
    else if (xs.length != ys.length)
        throw new Exception("given lists have to be of equal size")
    (for ((x, y) <- xs.zip(ys)) yield {x * y}).sum
}


//checks if n is prime
def isPrimeUgly(n: Int): Boolean = {
    var i = 2
    while (i < n) {
        if (n % i == 0) return false
        i += 1
    }
    n > 1
}

def isPrime(n: Int): Boolean = {
    !(for (i <- 1 to n-1; j <- 2 to n-1) yield {i * j}).contains(n) && n > 1
}

//for given positive integer n, find all pairs of integers i and j,
//where 1 ≤ j < i < n such that i + j is prime
def primePairsUgly(n : Int): List[(Int, Int)] = {
    var i = 1
    var l = new ListBuffer[(Int, Int)]()
    while (i < n) {
        var j = 1
        while (j < n) {
            if (isPrimeUgly(i+j)) l += ((i, j))
            j += 1
        }
        i += 1
    }
    l.toList
}

def primePairs(n : Int): List[(Int, Int)] = {
    for(i <- (1 until n).toList; 
        j <- (1 until n).toList if isPrime(i+j)) yield (i, j)
}

//create a list with all lines from given file
val filesHere = new java.io.File(".").listFiles
def fileLinesUgly(file: java.io.File): List[String] = {
    var l = new ListBuffer[String]()
    var lines = Source.fromFile(file).getLines()
    while (lines.hasNext) {
        l += lines.next()
    }
    l.toList
}

def fileLines(file: java.io.File): List[String] = {
    (for(line <- Source.fromFile(file).getLines()) yield line).toList
}

//print names of all .scala files which are in filesHere & are non
//empty
def printNonEmptyUgly(pattern: String): Unit = {
    try {
        var dir = new File(pattern)
        if (!dir.isDirectory) throw new Exception("given pattern is not a directory")
    
        var files = dir.listFiles
        var i = 0
        while (i < files.length) {
            var file = files(i)
            if (file.isFile && file.length != 0 && file.getName.endsWith(".scala")) {
                println(file.getName)
            }
            i += 1
        }
    }
    catch {
        case _: Throwable => throw new Exception("error opening given path")
    }    
}

def printNonEmpty(pattern: String): Unit = {
    try {
        val dir = new File(pattern)
        if (!dir.isDirectory) throw new Exception("given pattern is not a directory")

        for(file <- dir.listFiles
            if file.isFile && file.length != 0 && file.getName.endsWith(".scala"))
            println(file.getName)
    }
    catch {
        case _: Throwable => throw new Exception("error opening given path")
    } 
}
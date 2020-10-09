//scalar product of two vectors xs and ys
def scalarUgly(xs: List[Int], ys: List[Int]) = {
    var product = 0;
    var i = 0;
    do {
        product += xs(i) * ys(i);
        i += 1;
    } while (i < xs.length);
    product
}

def scalar(xs: List[Int], ys: List[Int]) = {
    (for ((x, y) <- xs.zip(ys)) yield {x * y}).sum
}


println(scalarUgly(List(1,2,3), List(4,5,6)))
println(scalar(List(1,2,3), List(4,5,6)))
object Utils {
  // checks if as is sorted according to ordering
  def isSorted(as: List[Int], ordering: (Int, Int) => Boolean): Boolean = {
    as match {
      case Nil      => true
      case x :: Nil => true
      case x :: y :: t =>
        if (ordering(x, y)) isSorted(y :: t, ordering)
        else false
    }
  }

  // checks if as is sorted in ascending order
  def isAscSorted(as: List[Int]) = isSorted(as, _ < _)

  // checks if as is sorted in descending order
  def isDescSorted(as: List[Int]) = isSorted(as, _ > _)

  // applies binary operator to a start value and all elements of l,
  // going  left to right
  def foldLeft[A, B](l: List[A], z: B)(f: (B, A) => B): B = {
    l match {
      case Nil     => z
      case h :: tl => foldLeft(tl, f(z, h))(f)
    }
  }

  // sum elements of l with usage of foldLeft function
  def sum(l: List[Int]) = foldLeft(l, 0)(_ + _)

  // length of l with usage of foldLeft function
  def length[A](l: List[A]) = foldLeft(l, 0)((acc, _) => acc + 1)

  // compose two unary functions:compose(f,g)(x) = f(g(x))
  def compose[A, B, C](f: B => C, g: A => B) = (x: A) => f(g(x))

  // takes unary function f with integer n & returns
  // the n-th repeated application of the function
  def repeated[A, B](f: Int => Int, n: Int) = {
    /*
    -in the example n seems to be a counter as well as an argument of the innermost function
    -i couldn't come up with idea of how to make argument f anything but Int=>Int,
    because i was getting type mismatches, so a quick how-to would be appreciated
     */
    require(n >= 0, "can't repeat function <0 many times")
    def rptd(i: Int, acc: Int): Int = {
      i match {
        case 0 => acc
        case _ => rptd(i - 1, f(acc))
      }
    }
    rptd(n, n)
  }

  // converts a binary function f of two arguments into
  // a function of one argument that partially applies f
  def curry[A, B, C](f: (A, B) => C) = (x: A) => (y: B) => f(x, y)

  // reverse of curry function
  def uncurry[A, B, C](f: A => B => C) = (x: A, y: B) => f(x)(y)

  // catch any exception, log the error & throw the ex exception instead
  def unSafe[T](ex: Exception)(code: => Unit) = {
    try {
      code
    } catch {
      case e: Exception => {
        println(s"an error occured - ${e.getLocalizedMessage()}")
        throw ex
      }
    }
  }
}

object main extends App {
  import Utils._
  println(isSorted(List(1, 2, 3), (x, y) => x < y))
  println(isAscSorted(List(1, 2, 3)))
  println(foldLeft(List(1, 2, 3), 0)((x, y) => x + y))
  println(sum(List(1, 2, 3)))
  println(length(List(1, 2, 3, 4, 5, 6, 7)))
  println(compose((x: Int) => x * x, (x: Int) => x + x)(2))
  def add(a: Int, b: Int) = a + b
  def f = (x: Int) => (y: Int) => x + y
  println(curry(add)(1)(1))
  println(uncurry(curry(add))(1, 1))
  println(uncurry(f)(1, 1))
  println(repeated((x: Int) => x * x, 2))
  unSafe(new Exception("essa")){
    throw new Exception("ups")
  }
}
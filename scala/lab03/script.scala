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
  def isAscSorted(as: List[Int]) = isSorted(as, (x, y) => x < y)

  // checks if as is sorted in descending order
  def isDescSorted(as: List[Int]) = isSorted(as, (x, y) => x > y)

  // applies binary operator to a start value and all elements of l,
  // going  left to right. Dont use build-in List.foldLeft1
  def foldLeft[A, B](l: List[A], z: B)(f: (B, A) => B): B = {
    l match {
      case Nil     => z
      case h :: tl => foldLeft(tl, f(z, h))(f)
    }
  }

  // sum elements of l with usage of foldLeft function
  def sum(l: List[Int]) = foldLeft(l, 0)(_ + _)

  // length of l with usage of foldLeft function
  def length[A](l: List[A]) = foldLeft(l, 0)((x, _) => x + 1)

  // compose two unary functions:compose(f,g)(x) = f(g(x))
  def compose[A, B, C](f: B => C, g: A => B) = (x: A) => f(g(x))

  // takes unary function f with integer n & returns
  // the n-th repeated application of the function
  // todo: def repeated[A, B](f: A => B, n: Int) = ???

  // converts a binary function f of two arguments into
  // a function of one argument that partially applies f
  // todo: def curry[A, B, C](. . .) = ???

  // reverse of curry function
  // todo: def uncurry[A, B, C](. . .) = ???
}

object main extends App {
  import Utils._
  println(isSorted(List(1, 2, 3), (x, y) => x < y))
  println(isAscSorted(List(1, 2, 3)))
  println(foldLeft(List(1, 2, 3), 0)((x, y) => x + y))
  println(sum(List(1, 2, 3)))
  println(length(List(1, 2, 3, 4, 5, 6, 7)))
  println(compose((x: Int) => x * x, (x: Int) => x + x)(2))
}

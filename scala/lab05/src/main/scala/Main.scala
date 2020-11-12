import Plugins._

package Plugins {

  trait Reverting {
    def revert(text: String): String = text.reverse
  }

  trait LowerCasing {
    def lowercase(text: String): String = text.map(_.toLower)
  }

  trait SingleSpacing {
    def singlespace(text: String): String =
      text.replaceAll(" +", " ")
  }

  trait NoSpacing {
    def nospace(text: String): String =
      text.replaceAll(" +", "")
  }

  trait DuplicateRemoval {
    def removeDuplicateChars(text: String): String =
      text.filter(c => text.count(_ == c) <= 1)
  }

  trait Rotating {
    def rotate(text: String): String =
      text.lastOption match {
        case None => ""
        case Some(c) => c + text.dropRight(1)
      }
  }

  trait Doubling {
    def doubleEverySecond(text: String): String =
      text.grouped(2).collect {
        case ab if ab.length == 2 => ab + ab.last
        case a => a
      }.mkString("")
  }

  trait Shortening {
    def removeEverySecond(text: String): String =
      text.grouped(2).collect {
        case ab if ab.length == 2 => ab.dropRight(1)
        case a => a
      }.mkString("")
  }

}

object Actions {

  abstract class Pluginable() {
    val plgnFunction: String => String

    def plugin(text: String): String = plgnFunction(text)
  }

  val actionA: Pluginable = new Pluginable with SingleSpacing with Doubling with Shortening {
    override val plgnFunction: String => String =
      singlespace _ andThen doubleEverySecond andThen removeEverySecond
  }

  val actionB: Pluginable = new Pluginable with NoSpacing with Shortening with Doubling {
    override val plgnFunction: String => String =
      nospace _ andThen removeEverySecond andThen doubleEverySecond
  }

  val actionC: Pluginable = new Pluginable with LowerCasing with Doubling {
    override val plgnFunction: String => String = lowercase _ andThen doubleEverySecond
  }

  val actionD: Pluginable = new Pluginable with DuplicateRemoval with Rotating {
    override val plgnFunction: String => String = removeDuplicateChars _ andThen rotate
  }

  val actionE: Pluginable = new Pluginable with NoSpacing with Shortening with Doubling with Reverting {
    override val plgnFunction: String => String =
      nospace _ andThen removeEverySecond andThen doubleEverySecond andThen revert
  }

  val actionF: Pluginable = new Pluginable with Rotating {
    private def repeat[A](n: Int, f: A => A): A => A = if (n == 1) f else f.andThen(repeat(n - 1, f))

    override val plgnFunction: String => String = repeat(5, rotate)
  }

  val actionG: Pluginable = new Pluginable {
    override val plgnFunction: String => String = actionA.plgnFunction andThen actionB.plgnFunction
  }
}

object Main extends App {

  class nop()

  val test = new nop()
    with Reverting with LowerCasing with SingleSpacing with NoSpacing
    with DuplicateRemoval with Rotating with Doubling with Shortening
  println(test.revert("abcdefgh"))
  println(test.lowercase("ABCdeFGh"))
  println(test.singlespace("ala ma   kota"))
  println(test.nospace("ala ma   kota"))
  println(test.removeDuplicateChars("alzaa  cda"))
  println(test.rotate("abc"))
  println(test.doubleEverySecond("abcd"))
  println(test.removeEverySecond("ab cd"))
  println("***")

  val a = Actions.actionA
  println(a.plugin("scala"))
  println(a.plugin(" sc            al a"))
  println(a.plugin(""))
  println("***")

  val b = Actions.actionB
  println(b.plugin("s c A l a"))
  println(b.plugin("s   ccc a l a"))
  println(b.plugin(""))
  println("***")

  val c = Actions.actionC
  println(c.plugin("SCALA"))
  println(c.plugin("s cALA"))
  println(c.plugin(""))
  println("***")

  val d = Actions.actionD
  println(d.plugin("SCALA"))
  println(d.plugin("scALA "))
  println(d.plugin(""))
  println("***")

  val e = Actions.actionE
  println(e.plugin("S   CA  LA"))
  println(e.plugin("s cAL A "))
  println(e.plugin(""))
  println("***")

  val f = Actions.actionF
  println(f.plugin("scala"))
  println(f.plugin("s cALA "))
  println(f.plugin(""))
  println("***")

  val g = Actions.actionG
  println(g.plugin("a  a"))
  println(g.plugin("                   dsf"))
  println(g.plugin(""))
  println("***")
}
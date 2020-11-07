import Deck._
import Cards._
import Games._

package Cards {

  sealed trait Color

  case object Heart extends Color

  case object Diamond extends Color

  case object Spade extends Color

  case object Club extends Color

  sealed trait Value

  case object Card2 extends Value

  case object Card3 extends Value

  case object Card4 extends Value

  case object Card5 extends Value

  case object Card6 extends Value

  case object Card7 extends Value

  case object Card8 extends Value

  case object Card9 extends Value

  case object Card10 extends Value

  case object Jack extends Value

  case object Queen extends Value

  case object King extends Value

  case object Ace extends Value

  case class Card(color: Cards.Color, value: Cards.Value)

}

package Deck {

  class Deck(var cards: List[Card]) {
    // checks if deck is a standard deck
    val isStandard: Boolean = cards.distinct.length == 52 && cards.length == 52
    //amount of all numerical cards in the deck
    val amountWithNumerical: Int = cards.count(c => isNumerical(c.value))
    //amount of all cards in the deck with faces
    val amountWithFace: Int = cards.count(c => isFace(c.value))
    //check if there is no cards left
    val emptyDeck: Boolean = cards.isEmpty

    //take the card on top
    def take(): Card = {
      require(cards.nonEmpty, "there are no more cards!")
      cards.head
    }

    //creates new deck without first card
    def pull(): Deck = {
      require(cards.nonEmpty, "there are no more cards!")
      new Deck(cards.tail)
    }

    //creates new deck with given card pushed on top
    def push(c: Card): Deck = new Deck(c :: cards)

    //creates new deck with new card(color, value) pushed on top
    def push(color: Color, value: Value): Deck = new Deck(Card(color, value) :: cards)

    //amount of duplicates of the given card in the deck
    def duplicatesOfCard(card: Card): Int = cards.count(c => c == card)

    //amount of cards in the deck for the given color
    def amountOfColor(color: Color): Int = cards.count(c => c.color == color)

    //amount of cards in the deck for given numerical card
    def amountOfNumerical(numerical: Value): Int = {
      require(isNumerical(numerical), "given card value must be numerical")
      cards.count(c => c.value == numerical)
    }

    private def isNumerical(value: Value): Boolean = {
      value match {
        case Jack | Queen | King | Ace => false
        case _ => true
      }
    }

    //amount of cards in the deck for the given face
    def amountOfFace(face: Value): Int = {
      require(isFace(face), "given card value must be a face")
      cards.count(c => c.value == face)
    }

    private def isFace(value: Value): Boolean = {
      value match {
        case Jack | Queen | King => true
        case _ => false
      }
    }

    val len: Int = cards.length
  }

  object Deck {

    import scala.util.Random

    def apply(): Deck = {
      val crds: List[Card] =
        for {v <- List(Card2, Card3, Card4, Card5, Card6, Card7, Card8, Card9, Card10, Jack, Queen, King, Ace)
             c <- List(Heart, Diamond, Spade, Club)} yield Card(c, v)
      new Deck(Random.shuffle(crds))
    }
  }

}

package Games {

  class Blackjack(var deck: Deck) {
    def play(n: Int): Unit = {
      var crds: List[Card] = List.empty
      for (_ <- 0 until n) {
        crds = deck.take() :: crds
        deck = deck.pull()
      }
      val counted = sumPoints(crds)
      var aceVals = counted._2
      for (c <- crds) {
        if (c.value == Ace) {
          println(s"${cardToString(c)} - ${aceVals.head}")
          aceVals = aceVals.tail
        } else {
          println(s"${cardToString(c)} - ${cardToPoints(c)}")
        }
      }
      println(s"total sum: ${counted._1}")
      if (counted._1 == 21) println("BLACKJACK!!")
    }

    private def cardToPoints(card: Card): Int = {
      card.value match {
        case Card2 => 2
        case Card3 => 3
        case Card4 => 4
        case Card5 => 5
        case Card6 => 6
        case Card7 => 7
        case Card8 => 8
        case Card9 => 9
        case Card10 | Jack | Queen | King => 10
        case Ace => 1 //should never happen
      }
    }

    private def cardToString(card: Card): String = {
      val v = card.value match {
        case Card2 => "2"
        case Card3 => "3"
        case Card4 => "4"
        case Card5 => "5"
        case Card6 => "6"
        case Card7 => "7"
        case Card8 => "8"
        case Card9 => "9"
        case Card10 => "10"
        case Jack => "J"
        case Queen => "Q"
        case King => "K"
        case Ace => "A"
      }
      val c = card.color match {
        case Spade => "\u2660"
        case Heart => "\u2665"
        case Diamond => "\u2666"
        case Club => "\u2663"
      }
      v + c
    }

    private def sumPoints(cards: List[Card]): (Int, List[Int]) = {
      // sum values of cards without aces
      val sum: Int =
        cards
          .filter(c => c.value != Ace)
          .foldLeft(0)((z, c: Card) => z + cardToPoints(c))
      // check if any combinations of values of aces sum to 21
      val aces: List[Card] = cards.filter(c => c.value == Ace)
      if (aces.nonEmpty) {
        val acesVals =
          List.fill(aces.length)(List(1, 11))
            .flatten
            .combinations(aces.length)
            .toList
        // return the sum and values for aces if score of 21 is achievable
        for (v <- acesVals) {
          if (sum + v.sum == 21) return (21, v)
        }
        // if not, the values don't matter
        return (sum + acesVals.head.sum, acesVals.head)
      }
      (sum, List.empty)
    }
  }

  object Blackjack {
    def apply(numOfDecks: Int): Blackjack = {
      require(numOfDecks > 0, "you can't play without cards! numOfDecks must be >0")
      var d = Deck()
      for (_ <- 1 until numOfDecks) {
        var nd = Deck()
        // reusing previously defined methods
        while (!nd.emptyDeck) {
          d = d.push(nd.take())
          nd = nd.pull()
        }
      }
      new Blackjack(d)
    }
  }

}

object Main extends App {
  println("let's create a new deck")
  var d = Deck()
  println(s"is the deck standard? ${d.isStandard}")
  println(s"amount with face cards: ${d.amountWithFace}")
  println(s"amount of numerical cards: ${d.amountWithNumerical}")
  println(s"amount of sevens: ${d.amountOfNumerical(Card7)}")
  val c = d.take()
  println(s"let's take a card $c")
  d = d.pull()
  println(s"now, is the deck still standard? ${d.isStandard}")
  println(s"amount of numerical cards: ${d.amountWithNumerical}")
  println(s"amount with face cards: ${d.amountWithFace}")
  println("let's put our card back 2 times")
  d = d.push(c).push(c)
  println(s"now there are ${d.duplicatesOfCard(c)} $c cards")
  println(s"so it shouldn't be standard - ${d.isStandard}")
  println("let's play blackjack with our deck and pull 3 cards")
  val b = new Blackjack(d)
  b.play(3)
  println("or try to play with 4 new decks at once")
  val b2 = Blackjack(4)
  b2.play(3)
}

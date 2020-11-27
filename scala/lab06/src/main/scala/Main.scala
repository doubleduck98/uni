import pizzeria._
import pizzeria.pizza._
import pizzeria.drinks._
import pizzeria.discounts._
import orders._

package pizzeria {

  package pizza {

    sealed trait PizzaType {
      val price: Double
    }

    case object Margherita extends PizzaType {
      override val price: Double = 5

      override def toString: String = "margherita"
    }

    case object Pepperoni extends PizzaType {
      override val price: Double = 6.5

      override def toString: String = "pepperoni"
    }

    case object Funghi extends PizzaType {
      override val price: Double = 7

      override def toString: String = "funghi"
    }


    sealed trait PizzaSize {
      val priceMultiplier: Double
    }

    case object Small extends PizzaSize {
      override val priceMultiplier: Double = 0.9

      override def toString: String = "small"
    }

    case object Regular extends PizzaSize {
      override val priceMultiplier: Double = 1

      override def toString: String = "regular size"
    }

    case object Large extends PizzaSize {
      override val priceMultiplier: Double = 1.5

      override def toString: String = "large"
    }


    sealed trait CrustType

    case object Thin extends CrustType {
      override def toString: String = "on thin crust"
    }

    case object Thick extends CrustType {
      override def toString: String = "on thick crust"
    }


    sealed trait Topping {
      val price: Double
    }

    case object Ketchup extends Topping {
      override val price: Double = 0.5

      override def toString: String = " with additional ketchup"
    }

    case object Garlic extends Topping {
      override val price: Double = 0.5

      override def toString: String = " with additional garlic"
    }


    sealed trait ExtraMeat {
      val price: Double
    }

    case object Salami extends ExtraMeat {
      override val price: Double = 1

      override def toString: String = " with extra salami"
    }

  }

  package drinks {

    sealed trait Drink {
      val price: Double
    }

    case object Lemonade extends Drink {
      override val price: Double = 2

      override def toString: String = f"lemonade, $$$price%.2f"
    }

  }

  package discounts {

    sealed trait Discount {
      val discountMultiplier: Double
    }

    case object SeniorDiscount extends Discount {
      override val discountMultiplier: Double = 0.93

      override def toString: String = "senior discount counted in\n"
    }

    case object StudentDiscount extends Discount {
      override val discountMultiplier: Double = 0.95

      override def toString: String = "student discount counted in\n"
    }

  }

  case class Pizza(pizzaType: PizzaType,
                   size: PizzaSize,
                   crustType: CrustType,
                   extraMeat: Option[ExtraMeat],
                   extraTopping: Option[Topping]) {

    override def toString: String =
      s"$size $pizzaType pizza $crustType" +
        s"${extraMeat.getOrElse("": String)}" +
        s"${extraTopping.getOrElse("": String)}, " +
        f"price: $$$price%.2f"

    val price: Double =
      (pizzaType.price
        + extraMeat.map(_.price).getOrElse(0.0)
        + extraTopping.map(_.price).getOrElse(0.0)) * size.priceMultiplier
  }

  object Pizza {
    def apply(pizzaType: PizzaType,
              size: PizzaSize,
              crustType: CrustType,
              extraMeat: ExtraMeat = null,
              extraTopping: Topping = null): Pizza =
      new Pizza(pizzaType, size, crustType, Option(extraMeat), Option(extraTopping))
  }

}

package orders {

  class Order(name: String,
              address: String,
              phone: String,
              pizzas: List[Pizza],
              drinks: List[Drink],
              discount: Option[Discount],
              specialInfo: Option[String]) {
    private[this] val phoneR: String = {
      // 9-digit cellphone numbers, optionally using - or spaces
      // 7-digit landline phone numbers, same
      """^\d{9}|^(\d{3}[ -]){2}\d{3}$|^\d{7}|^(\d{2}[ -]){2}\d{3}$"""
    }
    require(phone.matches(phoneR), "invalid phone number format")

    override def toString: String =
      "――address――\n" +
        name + "\n" + address + "\n" + phone + "\n" +
        "――order――\n" +
        pizzas.mkString("\n") + "\n" +
        drinks.mkString("\n") + "\n" +
        discount.getOrElse("") +
        specialInfo.getOrElse("") + "\n" +
        f"――$$$price%.2f――"

    // so i figured since pizzas and drinks are lists then we should just return 0
    // if they are empty, however if we wanted to protect ourselves from 'pizzas'
    // being null, we could do
    //    Option(pizzas) match {
    //      case None => None
    //      case Some(pizzas) => ..calculations
    //    }
    // but i don't know if that is what we are aiming for
    // (applies to all four functions below)
    def extraMeatPrice: Option[Double] =
      Some(pizzas.flatMap(_.extraMeat).foldLeft(0.0)((acc, xm) => acc + xm.price))

    def pizzasPrice: Option[Double] =
      Some(pizzas.foldLeft(0.0)((acc, p: Pizza) => acc + p.price))

    def drinksPrice: Option[Double] =
      Some(drinks.foldLeft(0.0)((acc, d: Drink) => acc + d.price))

    def priceByType(pType: PizzaType): Option[Double] =
      Some(pizzas
        .filter(_.pizzaType == pType)
        .foldLeft(0.0)((acc, p: Pizza) => acc + p.price))

    val price: Double =
      (pizzasPrice.getOrElse(0.0) + drinksPrice.getOrElse(0.0)) *
        discount.map(_.discountMultiplier).getOrElse(1.0)
  }

  object Order {
    def apply(name: String,
              address: String,
              phone: String,
              pizzas: List[Pizza],
              drinks: List[Drink],
              discount: Discount = null,
              specialInfo: String = null): Order =
      new Order(name, address, phone, pizzas, drinks, Option(discount), Option(specialInfo))
  }

}

object Main extends App {
  val pizza1 = Pizza(Funghi, Regular, Thin)
  val pizza2 = Pizza(Margherita, Small, Thick, extraTopping = Ketchup)
  val pizza3 = Pizza(Funghi, Regular, Thick, Salami)
  val pizza4 = Pizza(Pepperoni, Large, Thin)
  println(pizza1)
  println(pizza2)
  println(pizza3)
  println(pizza4)
  println("***")

  val order1 = Order("Cc", "ul. Dd", "987654123", List(pizza1, pizza2), List.empty, discount = StudentDiscount)
  println(order1.price)
  println(order1.priceByType(Pepperoni))
  println(order1.priceByType(Funghi).get)
  println("***")

  val order2 = Order("Ee", "ul. Ff", "71-69-412", List(pizza3, pizza4), List.empty)
  println(order1.price)
  println(order1.extraMeatPrice.get)
  println("***")

  try {
    val order = Order("Aa", "ul. Bb", "12345678", List.empty, List.empty)
  } catch {
    case e: Exception => println(e.getMessage)
  }
  println("***")

  val order = Order("Szymon", "ul. E.Orzeszkowej 5/5", "799 997 123",
    List(pizza1, pizza2, pizza3, pizza4), List(Lemonade, Lemonade),
    StudentDiscount, "if no one is home, please leave the order at appartment 4")
  println(order)
}

package Main

import com.restfb.{DefaultFacebookClient, Parameter, Version}
import com.restfb.types.User

object FacebookAdapter {

  private val secret = "a9855939afb34b2c46350c37d9af700e"

  class facebookClient(accessToken: String)
    extends DefaultFacebookClient(accessToken, secret, Version.VERSION_5_0) {

  }

  def getUser(accessToken: String, id: String): User = {
    val client = new facebookClient(accessToken)
    val user = client.fetchObject(id, classOf[User])
    user
  }

  def getUserNameLikes(accessToken: String, id: String): User = {
    val client = new facebookClient(accessToken)
    // need to specify that we are going to also fetch user likes
    val user = client.fetchObject(id, classOf[User], Parameter.`with`("fields", "name,likes.summary(true)"))
    user
  }
}

object Logger {

  import java.io.{FileWriter, IOException}

  def logMessage(file: String, msg: String): Unit = {
    try {
      val fw = new FileWriter(file, true)
      fw.write(msg + '\n')
      fw.close()
    } catch {
      case e: IOException => println(e.getMessage)
    }
  }
}

object Comparator {

  import scala.concurrent.{Future, Await}
  import scala.concurrent.ExecutionContext.Implicits.global
  import scala.concurrent.duration.Duration

  private val accessToken = "EAAPVmU6ep9cBANo2ZBEZA4J5HtHYNnb2ZBOw8rXclEcfFfhxQBGiIhKS98M2OcAQqBZBHQ2Qx59fEbEM0XTHCtnBNxMTZBEXgF49YuQ56pQn32BogbTG4khxV1tUdPUfw0bHbD4PAXns6CuTZCktxvZANxFZBEcgTJwPbU6GhBek24qLnTed4Lr5E7DK22bHp3KN846RE99jjJ8Yzk3KpBZAd"

  private def getUser(id: String): Future[User] = Future {
    FacebookAdapter.getUserNameLikes(accessToken, id)
  }

  private def addLog(logFile: String, user1: String, user2: String): Future[Unit] = Future {
    val msg: String = s"${java.time.LocalDateTime.now.toString} $user1 $user2"
    Logger.logMessage(logFile, msg)
  }

  private def printComparison(user1: User, user2: User): Future[Unit] = Future {
    println(
      s"""${user1.getName}, likes: ${user1.getLikes.getTotalCount} vs.
         |${user2.getName}, likes: ${user2.getLikes.getTotalCount}""".stripMargin
    )
  }

  def compareLikes(logFile: String, user1: String, user2: String): Unit = {
    addLog(logFile, user1, user2)
    val future = for {
      u1 <- getUser(user1)
      u2 <- getUser(user2)
    } yield printComparison(u1, u2)
    Await.result(future, Duration.Inf)
  }
}

object Main extends App {

  import Comparator._

  // for the tests below i created 3 test users and some test pages for them
  // access token should not expire for the next 30 days
  compareLikes("logs.txt", "103652788307496", "100844555255204")
  compareLikes("logs.txt", "103652788307496", "101355358535449")
  compareLikes("logs.txt", "101355358535449", "100844555255204")
}

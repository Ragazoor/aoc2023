package ragazoor.aoc.day1

import ragazoor.aoc.day1.InputRepoMock.GetPart1
import zio.mock.{Mock, Proxy}
import zio.{Task, URLayer, ZLayer}

case class InputRepoMock(proxy: Proxy) extends InputRepo {
  override def getPart1: Task[Seq[String]] =
    proxy(GetPart1)

}

object InputRepoMock extends Mock[InputRepo]:
  object GetPart1 extends Method[Unit, Throwable, Seq[String]]

  val compose: URLayer[Proxy, InputRepo] =
    ZLayer.fromFunction(InputRepoMock.apply)



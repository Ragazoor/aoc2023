package ragazoor.aoc.day1

import zio.*

object Day1Main extends ZIOAppDefault:

  override def run: ZIO[Any, Throwable, Any] =
    program.
      provide(
        Day1.layer,
        InputRepoImpl.layer
      )

  private def program: RIO[Day, Unit] =
    for {
      _ <- Day.part1
      _ <- Day.part2
    } yield ()

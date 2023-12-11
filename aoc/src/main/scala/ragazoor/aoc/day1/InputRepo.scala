package ragazoor.aoc.day1

import zio.*

trait InputRepo:
    def getPart1: Task[Seq[String]]

object InputRepo:
    def getPart1: RIO[InputRepo, Seq[String]] =
        ZIO.serviceWithZIO(_.getPart1)
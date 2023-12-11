package ragazoor.aoc.day1

import zio.*
import scala.util.Try

trait InputRepo:
    def getPart1: Try[Seq[String]]

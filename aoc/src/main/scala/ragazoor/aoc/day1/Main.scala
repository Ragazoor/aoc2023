package ragazoor.aoc.day1
import zio.*

@main def program =
  val day1 = new Day1(InputRepoImpl)
  day1.part1

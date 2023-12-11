package ragazoor.aoc.day1

import zio.*


case class Day1(inputRepo: InputRepo) extends Day:
  def part1: Task[Unit] =
    for {
      input <- inputRepo.getPart1
      result = getPart1(input)
      _ <- Console.printLine(result)
    } yield ()

  private def getPart1(input: Seq[String]): Int =
    input.map { line =>
      val numbers = line.toCharArray.filter(_.isDigit)
      val firstNum = numbers.head.toString
      val lastNum = numbers.last.toString
      (firstNum + lastNum).toInt
    }.sum

  def part2: Task[Unit] = ???

object Day1:
  val layer: URLayer[InputRepo, Day1] =
    ZLayer.fromFunction(Day1.apply _)

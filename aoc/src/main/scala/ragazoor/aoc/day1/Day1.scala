package ragazoor.aoc.day1

import zio.*

case class Day1(inputRepo: InputRepo) extends Day:
  type Index = Int

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

  def part2: Task[Unit] =
    for {
      input <- inputRepo.getPart1
      result = getPart2(input)
      _ <- Console.printLine(result)
    } yield ()

  val numbers = Seq("one", "two", "three", "four", "five", "six", "seven", "eight", "nine")

  def string2Number(number: String): Int = numbers.indexOf(number) + 1

  private def getPart2(input: Seq[String]): Int =
    input.map { line =>
      val firstNumIdx = getNumIdx(line)(_.toCharArray.indexWhere(_.isDigit))
      val lastNumIdx = getNumIdx(line)(_.toCharArray.lastIndexWhere(_.isDigit))
      val firstNumStr = getStringNums(line.indexOf).headOption
      val lastNumStr = getStringNums(line.lastIndexOf).lastOption
      def firstCompare(a: (Index, String),b: (Index, String)) = if (a._1 < b._1) a._2 else b._2
      val firstNum = getStr(firstNumIdx, firstNumStr)(firstCompare)
      def lastCompare(a: (Index, String),b: (Index, String)) = if (a._1 > b._1) a._2 else b._2
      val lastNum = getStr(lastNumIdx, lastNumStr)(lastCompare)
      (firstNum + lastNum).toInt
    }.sum

  private def getNumIdx(line: String)(getIdx: String => Index): Option[(Index, String)] =
    val firstNumIdx = getIdx(line)
    if (firstNumIdx != -1) Some((firstNumIdx, line(firstNumIdx).toString)) else None

  private def getStr(digit: Option[(Index, String)], string: Option[(Index, String)])
                        (compare: ((Index, String), (Index, String)) => String): String =
    (digit, string) match
      case (Some((_, digit)), None) => digit
      case (None, Some((_, digit))) => digit
      case (Some(a), Some(b)) => compare(a, b)
      case (None, None) => throw new RuntimeException("Found neither string nor digit in line")

  private def getStringNums(getIdx: String => Int): Seq[(Index, String)] =
    numbers.flatMap(num =>
      val idx = getIdx(num)
      if (idx != -1) Some((idx, num)) else None
    ).sortBy((idx, _) => idx)
      .map((idx, num) => (idx, string2Number(num).toString))

object Day1:
  val layer: URLayer[InputRepo, Day1] =
    ZLayer.fromFunction(Day1.apply _)

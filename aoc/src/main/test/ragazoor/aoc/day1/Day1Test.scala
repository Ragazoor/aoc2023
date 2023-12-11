package ragazoor.aoc.day1

import ragazoor.aoc.day1.Day1Test.test
import zio.*
import zio.mock.Expectation
import zio.test.*
import zio.test.Assertion.*

object Day1Test extends ZIOSpecDefault {
  def spec = suite("Day1test")(
    test("Test day 1 part 1") {
      val inputRepo =
        InputRepoMock.GetPart1(
          Expectation.value(Seq(
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet")))

      val result = for {
        _ <- Day.part1
        output <- TestConsole.output
      } yield assertTrue(output.head == "142\n")

      result.provide(
        Day1.layer,
        inputRepo)
    },

    test("Test day 1 part 2") {
      val inputRepo =
        InputRepoMock.GetPart1(
          Expectation.value(Seq(
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen",
          )))

      val result = for {
        _ <- Day.part2
        output <- TestConsole.output
      } yield assertTrue(output.head == "281\n")

      result.provide(
        Day1.layer,
        inputRepo)
    }
  )
}
module Day1Tests

open Xunit
open AoC2023

[<Fact>]
let ``Part 1`` () =
  let input = [
    "1abc2";
    "pqr3stu8vwx";
    "a1b2c3d4e5f";
    "treb7uchet"]
  Assert.Equal(142, Day1.part1 input)

[<Fact>]
let ``Part 2`` () =
  let input = [
    "two1nine";
    "eightwothree";
    "abcone2threexyz";
    "xtwone3four";
    "4nineeightseven2";
    "zoneight234";
    "7pqrstsixteen"
    ]
  Assert.Equal(281, Day1.part2 input)
module Day3Tests

open Xunit
open AoC2023


[<Fact>]
let ``Part 1`` () =
  let input = [
    "467..114..";
    "...*......";
    "..35..633.";
    "......#...";
    "617*......";
    ".....+.58.";
    "..592.....";
    "......755.";
    "...$.*....";
    ".664.598..";
    ]
  Assert.Equal(4361, Day3.part1 input)

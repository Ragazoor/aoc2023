module Day2Tests

open Xunit
open AoC2023

[<Fact>]
let ``Test regex`` () =
  let input = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"
  let matches = Day2.firstRegex.Matches(input)

  let group1 = " 3 blue, 4 red"
  let group2 = " 1 red, 2 green, 6 blue"
  let group3 = " 2 green"

  Assert.Equal("1", matches[0].Groups[1].Captures[0].Value )
  Assert.Equal(group1, matches[0].Groups[2].Captures[0].Value )
  Assert.Equal(group2, matches[0].Groups[2].Captures[1].Value )
  Assert.Equal(group3, matches[0].Groups[2].Captures[2].Value )

  Assert.Equal("1", Day2.secondRegex.Matches(group2).[0].Groups[1].Captures[0].Value )
  Assert.Equal("2", Day2.secondRegex.Matches(group2).[0].Groups[1].Captures[1].Value )
  Assert.Equal("6", Day2.secondRegex.Matches(group2).[0].Groups[1].Captures[2].Value )

  Assert.Equal("red", Day2.secondRegex.Matches(group2).[0].Groups[2].Captures[0].Value )
  Assert.Equal("green", Day2.secondRegex.Matches(group2).[0].Groups[2].Captures[1].Value )
  Assert.Equal("blue", Day2.secondRegex.Matches(group2).[0].Groups[2].Captures[2].Value )


[<Fact>]
let ``Part 1`` () =
  let input = [
    "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
    "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue";
    "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red";
    "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red";
    "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";
    ]
  Assert.Equal(8, Day2.part1 input)

[<Fact>]
let ``Part 2`` () =
  let input = [
    "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
    "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue";
    "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red";
    "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red";
    "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";
    ]
  Assert.Equal(2286, Day2.part2 input)


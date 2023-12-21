namespace AoC2023
open AoC2023.Common

module Day2 =

  let firstRegex = System.Text.RegularExpressions.Regex(@"Game (\d+):(?:((?:(?: \d+ \w+),)*(?: \d+ \w+))(?:;?))+")
  let secondRegex = System.Text.RegularExpressions.Regex(@"(?: (?:(\d+) (\w+)),?)+")
  let private getGameResult input =
    0
  let private part1 input = input |> List.sumBy getGameResult

  let solver = { part1 = part1; part2 = part1}

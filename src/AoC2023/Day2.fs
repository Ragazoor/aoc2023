namespace AoC2023
open AoC2023.Common

module Day2 =

  type private Cubes = {red: int; green: int; blue: int}
  type private Game = {id: int; cubes: Cubes seq}
  let private isImpossibleGame cube =
    cube.red > 12 || cube.green > 13 || cube.blue > 14
  let private getIdIfValidGame game =
      if Seq.exists isImpossibleGame game.cubes then
        None
      else
        Some game.id
  let firstRegex = System.Text.RegularExpressions.Regex(@"Game (\d+):(?:((?:(?: \d+ \w+),)*(?: \d+ \w+))(?:;?))+")
  let secondRegex = System.Text.RegularExpressions.Regex(@"(?: (?:(\d+) (\w+)),?)+")
  let private parseGroup group =
      let matches = secondRegex.Matches(group)
      let countSeq = matches.[0].Groups.[1].Captures |> Seq.map (fun c -> c.Value |> int)
      let colorSeq = matches.[0].Groups.[2].Captures |> Seq.map (fun c -> c.Value)
      let colorMap = Map.ofSeq (Seq.zip colorSeq countSeq)
      let red = Map.tryFind "red" colorMap |> Option.defaultValue 0
      let green = Map.tryFind "green" colorMap |> Option.defaultValue 0
      let blue = Map.tryFind "blue" colorMap |> Option.defaultValue 0
      {red = red; green = green; blue = blue}
  let private parseGame line =
    let matches = firstRegex.Matches(line)
    let gameNumber = matches.[0].Groups.[1].Captures.[0].Value |> int
    let cubes =
      matches.[0].Groups.[2].Captures
      |> Seq.map (fun c -> c.Value)
      |> Seq.map parseGroup
    {id = gameNumber; cubes = cubes}

  let private getGameResult1 (gameStr: string) =
    gameStr
    |> parseGame
    |> getIdIfValidGame
    |> Option.defaultValue 0
  let private getMinCubes' currentMinCube cube =
    let minRed = max currentMinCube.red cube.red
    let minGreen = max currentMinCube.green cube.green
    let minBlue = max currentMinCube.blue cube.blue
    {red = minRed; green = minGreen; blue = minBlue}

  let private getMinCubes game =
    game.cubes
    |> Seq.reduce getMinCubes'
    |> (fun c -> c.red * c.green * c.blue)

  let private getGameResult2 (gameStr: string) =
    gameStr
    |> parseGame
    |> getMinCubes

  let part1 input = input |> List.sumBy getGameResult1
  let part2 input = input |> List.sumBy getGameResult2
  let solver = { part1 = part1; part2 = part2}

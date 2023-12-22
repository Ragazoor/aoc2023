namespace AoC2023

open AoC2023.Common

module Day3 =
    // If a number spans the coordinates (x,y) to (x+1,y) then the number exists on both keys of the map
    type Numbers = Map<int * int, int>
    type Symbols = seq<int * int>

    type Schematic =
        { numbers: Numbers
          symbols: (int * int) seq }

    let private parseSchematic (input: string list) : Schematic = {  }

    let private getNeighbourNumbers (numbers: Numbers) (x, y) =
        [ numbers.[x - 1, y - 1]
          numbers.[x - 1, y]
          numbers.[x - 1, y + 1]
          numbers.[x, y - 1]
          numbers.[x, y + 1]
          numbers.[x + 1, y - 1]
          numbers.[x + 1, y]
          numbers.[x + 1, y + 1] ]

    let part1 input =
        input
        |> parseSchematic
        |> fun s -> s.symbols |> Seq.iter

    let solver = { part1 = part1; part2 = part1 }

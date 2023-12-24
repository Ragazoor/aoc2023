namespace AoC2023

open AoC2023.Common
open System

// Assuming no symbol can be neighbouring two symbols
// Assuming no two identical numbers are neighbours to same symbol
module Day3 =
    // If a number spans the coordinates (x,y) to (x+1,y) then the number exists on both keys of the map
    type Numbers = Map<int * int, int>
    type Symbols = seq<int * int>

    type Schematic =
        { numbers: Numbers
          symbols: (int * int) seq }

    let private numberRegex = System.Text.RegularExpressions.Regex(@"\d+")
    let private symbolRegex = System.Text.RegularExpressions.Regex(@"[^\d\.]")

    let parseSchematic (input: string list) : Schematic =
        input
        |> Seq.mapi (fun y line ->
            let numbers: Map<int * int, int> =
                numberRegex.Matches(line)
                |> Seq.map (fun m -> m.Index, int m.Value)
                |> Seq.map (fun (x, n) ->
                    let len = Math.Log10 n |> int |> (+) 1
                    Seq.init len (fun i -> (x + i, y), n))
                |> Seq.concat
                |> Map.ofSeq

            let symbols =
                symbolRegex.Matches(line)
                |> Seq.map (fun m -> (m.Index, y))

            { numbers = numbers; symbols = symbols })
        |> Seq.reduce (fun acc s ->
            { numbers = Map.fold (fun acc k v -> Map.add k v acc) acc.numbers s.numbers
              symbols = Seq.append s.symbols acc.symbols })

    let private getNeighbourNumbers (numbers: Numbers) (x, y) =
        [ numbers.TryFind(x - 1, y - 1)
          numbers.TryFind(x - 1, y)
          numbers.TryFind(x - 1, y + 1)
          numbers.TryFind(x, y - 1)
          numbers.TryFind(x, y + 1)
          numbers.TryFind(x + 1, y - 1)
          numbers.TryFind(x + 1, y)
          numbers.TryFind(x + 1, y + 1) ]
        |> List.choose id
        |> Set.ofList
        |> List.ofSeq

    let part1 input =
        input
        |> parseSchematic
        |> fun s ->
            s.symbols
            |> Seq.map (getNeighbourNumbers s.numbers)
        |> Seq.collect id
        |> Seq.sum

    let solver = { part1 = part1; part2 = part1 }

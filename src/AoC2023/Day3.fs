namespace AoC2023

open AoC2023.Common
open System

// Assuming no symbol can be neighbouring two symbols
// Assuming no two identical numbers are neighbours to same symbol
module Day3 =
    // If a number spans the coordinates (x,y) to (x+1,y) then the number exists on both keys of the map
    type Numbers = Map<int * int, int>
    type Symbols = Map<int * int, string>

    type Schematic = { numbers: Numbers; symbols: Symbols }

    let private numberRegex = Text.RegularExpressions.Regex(@"\d+")
    let private symbolRegex = Text.RegularExpressions.Regex(@"[^\d\.]")

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
                |> Seq.map (fun m -> m.Index, m.Value)
                |> Seq.map (fun (x, s) -> (x, y), s)
                |> Map.ofSeq

            { numbers = numbers; symbols = symbols })
        |> Seq.reduce (fun acc s ->
            { numbers = Map.fold (fun acc k v -> Map.add k v acc) acc.numbers s.numbers
              symbols = Map.fold (fun acc k v -> Map.add k v acc) acc.symbols s.symbols })

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
            s.symbols.Keys
            |> Seq.map (getNeighbourNumbers s.numbers)
        |> Seq.collect id
        |> Seq.sum

    let part2 input =
        input
        |> parseSchematic
        |> fun s ->
            s.symbols
            |> Map.filter (fun _ v -> v = "*")
            |> Map.keys
            |> Seq.map (getNeighbourNumbers s.numbers)
            |> Seq.filter (fun n -> n.Length > 1)
            |> Seq.map (List.reduce (*))
        |> Seq.sum

    let solver = { part1 = part1; part2 = part2 }

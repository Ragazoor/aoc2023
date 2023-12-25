namespace AoC2023

open AoC2023.Common
open System

// Assuming no symbol can be neighbouring two symbols
// Assuming no two identical numbers are neighbours to same symbol
module Day3 =
    // If a number spans the coordinates (x,y) to (x+1,y) then the number exists on both keys of the map
    type Coordinate = int * int
    type Numbers = Map<Coordinate, int>
    type Symbols = Map<Coordinate, string>

    type Schematic = { numbers: Numbers; symbols: Symbols }

    let private numberRegex = Text.RegularExpressions.Regex(@"\d+")
    let private symbolRegex = Text.RegularExpressions.Regex(@"[^\d\.]")

    let private getNumbers y line =
        numberRegex.Matches(line)
        |> Seq.map (fun m -> m.Index, int m.Value)
        |> Seq.map (fun (x, n) ->
            let len = Math.Log10 n |> int |> (+) 1
            Seq.init len (fun i -> (x + i, y), n))
        |> Seq.concat
        |> Map.ofSeq

    let private getSymbols y line =
        symbolRegex.Matches(line)
        |> Seq.map (fun m -> m.Index, m.Value)
        |> Seq.map (fun (x, s) -> (x, y), s)
        |> Map.ofSeq

    let parseSchematic (input: string list) : Schematic =
        input
        |> Seq.mapi (fun y line ->
            let numbers = getNumbers y line
            let symbols = getSymbols y line
            { numbers = numbers; symbols = symbols })
        |> Seq.reduce (fun acc s ->
            { numbers = mergeMap acc.numbers s.numbers
              symbols = mergeMap acc.symbols s.symbols })

    let private getNeighbourNumbers (numbers: Numbers) (x, y) =
        Seq.init 3 (fun i ->
            Seq.init 3 (fun j ->
                if i = 1 && j = 1 then
                    None
                else
                    numbers.TryFind(x + i - 1, y + j - 1)))
        |> Seq.concat
        |> Seq.choose id
        |> Set.ofSeq
        |> Set.toList

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

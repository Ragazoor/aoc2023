namespace AoC2023

open AoC2023.Common
open System

module Day4 =
    type Card =
        { id: int
          winNumbers: int Set
          myNumbers: int Set }

    let private regex =
        Text.RegularExpressions.Regex(@"Card +(\d+):( +\d+)+ \|( +\d+)+")

    let private parseCard line : Card =
        let matches = regex.Matches(line)
        let id = matches.[0].Groups.[1].Captures.[0].Value |> int

        let winNumbers =
            matches.[0].Groups.[2].Captures
            |> Seq.map (fun c -> c.Value |> int)
            |> Set.ofSeq

        let myNumbers =
            matches.[0].Groups.[3].Captures
            |> Seq.map (fun c -> c.Value |> int)
            |> Set.ofSeq

        { id = id
          winNumbers = winNumbers
          myNumbers = myNumbers }

    let part1 input =
        input
        |> Seq.map parseCard
        |> Seq.map (fun c -> Set.intersect c.winNumbers c.myNumbers)
        |> Seq.filter (Set.isEmpty >> not)
        |> Seq.map (fun x -> Math.Pow(2.0, (x.Count - 1) |> float))
        |> Seq.sumBy int

    let mergeMap m1 m2 =
        Map.fold
            (fun acc k v ->
                (let accVal = Map.tryFind k acc |> Option.defaultValue 0
                 Map.add k (v + accVal) acc))
            m1
            m2

    let private getNumScratchCards (cards: Card seq) =
        cards
        |> Seq.map (fun c -> c.id, (Set.intersect c.winNumbers c.myNumbers))
        |> Seq.map (fun (id, winNumbers) -> id, Set.count winNumbers)
        |> Map.ofSeq
        |> Map.fold
            (fun acc cardId numWins ->
                let numCurrentCard =
                    Map.tryFind cardId acc
                    |> Option.defaultValue 0
                    |> (+) 1

                let currentCardWinnings =
                    Seq.init numWins (fun i -> cardId + i + 1, numCurrentCard)
                    |> Map.ofSeq

                mergeMap acc currentCardWinnings
                |> Map.add cardId numCurrentCard)
            Map.empty

    let part2 input =
        input
        |> Seq.map parseCard
        |> getNumScratchCards
        |> Map.values
        |> Seq.sum


    let solver = { part1 = part1; part2 = part2 }

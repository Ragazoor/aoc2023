namespace AoC2023

open AoC2023.Common
open System

// For more information see https://aka.ms/fsharp-console-apps
module Program =
    let private getInput day =
        let exePath =
            Reflection
                .Assembly
                .GetExecutingAssembly()
                .Location

        let appDir = IO.Path.GetDirectoryName(exePath)

        let inputPath = IO.Path.Combine(appDir, $"../../../input/day%d{day}.txt")

        IO.File.ReadAllLines(inputPath) |> Seq.toList


    let printResult day input =
        let part1 = day.part1 input
        let part2 = day.part2 input
        let message = $"Part 1: %d{part1}, Part 2: %d{part2}\n"
        printfn "%s" message

    [<EntryPoint>]
    let main args =
        for day in 1..4 do
            printfn "Day %d" day
            let input = getInput day

            match day with
            | 1 -> printResult Day1.solver input
            | 2 -> printResult Day2.solver input
            | 3 -> printResult Day3.solver input
            | 4 -> printResult Day4.solver input
            | _ -> printfn "Not implemented yet"

        0

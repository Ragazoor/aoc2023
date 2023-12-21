namespace AoC2023

open AoC2023.Common

// For more information see https://aka.ms/fsharp-console-apps
module Program =
  let private getInput day =
    let exePath = System.Reflection.Assembly.GetExecutingAssembly().Location
    let appDir = System.IO.Path.GetDirectoryName(exePath)
    let inputPath = System.IO.Path.Combine(appDir, $"../../../input/Day%d{day}/input.txt")
    System.IO.File.ReadAllLines(inputPath)
    |> Seq.toList


  let printResult day input =
    let part1 = day.part1 input
    let part2 = day.part2 input
    let message = $"Part 1: %d{part1}, Part 2: %d{part2}\n"
    printfn "%s" message

  [<EntryPoint>]
  let main args =
    for day in 1..2 do
      printfn "Day %d" day
      let input = getInput day
      match day with
      | 1 -> printResult Day1.solver input
      | 2 -> printResult Day2.solver input
      | _ -> printfn "Not implemented yet"
    0

namespace AoC.Y2023

open Day1



// For more information see https://aka.ms/fsharp-console-apps
module Program =
  let private getInput day =
    let inputPath = $"src/AoC2023/Day%d{day}/input.txt"
    System.IO.File.ReadAllLines(inputPath)
    |> Seq.toList


  let printResult part1 part2 =
    let message = $"Part 1: %d{part1}, Part 2: %d{part2}"
    printfn "%s" message

  [<EntryPoint>]
  let main args =
    for day in 1..1 do
      printfn "Day %d" day
      let input = getInput day
      match day with
      | 1 -> printResult (Day1.part1 input) (Day1.part1 input)
      | _ -> printfn "Not implemented yet"
      printfn "\n"
    0

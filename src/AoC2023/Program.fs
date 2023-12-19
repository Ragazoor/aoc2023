namespace AoC.Y2023

open Day1


// For more information see https://aka.ms/fsharp-console-apps
module program =

  let printResult part1 part2 =
    let message = $"Part 1: %d{part1}, Part 2: %d{part2}"
    printfn "%s" message

  [<EntryPoint>]
  let main args =
    for day in 1..1 do
      printfn "Day %d" day
      match day with
      | 1 -> printResult Day1.part1 Day1.part1
      | _ -> printfn "Not implemented yet"
      printfn "\n"
    0

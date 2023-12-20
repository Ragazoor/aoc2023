namespace AoC2023

module Day1 =
  let private removeLetters str = str |> String.filter System.Char.IsDigit

  let private calibrationValue (str: string) =
    let first: string = str.[0].ToString()
    let last: string = str.[str.Length - 1].ToString()
    int (first + last)

  let private getCalibrationValue1 input = input |> removeLetters |> calibrationValue

  let part1 input =
    input |> List.sumBy getCalibrationValue1

  let private lookup = Map [
          ("1","1"); ("2","2"); ("3","3"); ("4","4"); ("5","5"); ("6","6"); ("7","7"); ("8","8");
          ("9","9"); ("0","0"); ("one","1"); ("two","2"); ("three","3"); ("four","4"); ("five","5");
          ("six","6"); ("seven","7"); ("eight","8"); ("nine","9")
      ]

  let private getNumberLine line: string =
    lookup.Keys |> Seq.fold (fun acc key -> acc.Replace(key, lookup[key])) line

  let private getCalibrationValue2 input = input |> getNumberLine |> removeLetters |> calibrationValue
  let part2 input = input |> List.sumBy getCalibrationValue2




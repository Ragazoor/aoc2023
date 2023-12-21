namespace AoC2023
open AoC2023.Common

module Day1 =
  let private removeLetters str = str |> String.filter System.Char.IsDigit

  let private calibrationValue (str: string) =
    let first: string = str.[0].ToString()
    let last: string = str.[str.Length - 1].ToString()
    int (first + last)

  let private getCalibrationValue1 input = input |> removeLetters |> calibrationValue

  let part1 input = input |> List.sumBy getCalibrationValue1

  let private lookup = Map [
          ("1","1"); ("2","2"); ("3","3"); ("4","4"); ("5","5"); ("6","6"); ("7","7"); ("8","8");
          ("9","9"); ("0","0"); ("one","1"); ("two","2"); ("three","3"); ("four","4"); ("five","5");
          ("six","6"); ("seven","7"); ("eight","8"); ("nine","9")
      ]

  let getAllIndices (str: string) (key: string) =
    let rec findIndexLoop (index: int) (indices: int list) =
      let index = str.IndexOf(key, index)
      if index >= 0 then
        findIndexLoop (index + 1) (index :: indices)
      else
        indices
    findIndexLoop 0 []

  let private getNumberLine (line: string) =
    let strArray  = Array.create line.Length ""
    for key in lookup.Keys do
      let indices = getAllIndices line key
      if indices.Length >= 0 then
        for idx in indices do
        strArray[idx] <- lookup[key]
    strArray |> Array.reduce (+)

  let private getCalibrationValue2 input = input |> getNumberLine |> calibrationValue
  let part2 input = input |> List.sumBy getCalibrationValue2

  let solver = { part1 = part1; part2 = part2}

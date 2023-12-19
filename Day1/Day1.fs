module Day1

open System

let getLines filePath =
  System.IO.File.ReadAllLines(filePath)
  |> Seq.toList

let input = getLines "Day1/input.txt"

let part1 =
  let removeLetters str = str |> String.filter System.Char.IsDigit

  let calibrationValue (str: string) =
    let first: string = str.[0].ToString()
    let last: string = str.[str.Length - 1].ToString()
    int (first + last)


  let getCalibrationValue input = input |> removeLetters |> calibrationValue
  (input |> List.sumBy getCalibrationValue)




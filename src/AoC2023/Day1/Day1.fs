module Day1

open System

let getLines filePath =
  System.IO.File.ReadAllLines(filePath)
  |> Seq.toList

let input = getLines "src/AoC2023/Day1/input.txt"
let removeLetters str = str |> String.filter System.Char.IsDigit

let calibrationValue (str: string) =
  let first: string = str.[0].ToString()
  let last: string = str.[str.Length - 1].ToString()
  int (first + last)

let getCalibrationValue1 input = input |> removeLetters |> calibrationValue

let part1 =
  (input |> List.sumBy getCalibrationValue1)





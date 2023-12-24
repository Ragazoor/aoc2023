module Day3Tests

open Xunit
open AoC2023


[<Fact>]
let ``Parse Schematic`` () =
    let input =
        [ "467..114.."
          "...*......"
          "..35..633."
          "......#..."
          "617*......"
          ".....+.58."
          "..592....."
          "......755."
          "...$.*...."
          ".664.598.." ]

    let expectedSymbols =
        [ (3, 1)
          (6, 3)
          (3, 4)
          (5, 5)
          (3, 8)
          (5, 8) ]
        |> Set.ofList

    let schematic = Day3.parseSchematic input
    Assert.True(Set.isSuperset expectedSymbols (Set.ofSeq schematic.symbols))

    Assert.Equal(467, schematic.numbers[0, 0])
    Assert.Equal(467, schematic.numbers[1, 0])
    Assert.Equal(467, schematic.numbers[2, 0])
    Assert.Equal(None, schematic.numbers.TryFind(3, 0))
    Assert.Equal(114, schematic.numbers[5, 0])
    Assert.Equal(114, schematic.numbers[6, 0])
    Assert.Equal(114, schematic.numbers[7, 0])
    Assert.Equal(617, schematic.numbers[0, 4])
    Assert.Equal(617, schematic.numbers[1, 4])
    Assert.Equal(617, schematic.numbers[2, 4])

[<Fact>]
let ``Part 1`` () =
    let input =
        [ "467..114.."
          "...*......"
          "..35..633."
          "......#..."
          "617*......"
          ".....+.58."
          "..592....."
          "......755."
          "...$.*...."
          ".664.598.." ]

    Assert.Equal(4361, Day3.part1 input)

namespace AoC2023

module Common =
  type Day<'a, 'b> = { part1: string list -> 'a; part2: string list -> 'b }

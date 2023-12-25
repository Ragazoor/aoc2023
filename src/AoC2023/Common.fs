namespace AoC2023

module Common =
    type Day<'a, 'b> =
        { part1: string list -> 'a
          part2: string list -> 'b }

    let mergeMap m1 m2 =
        Map.fold (fun acc k v -> Map.add k v acc) m1 m2

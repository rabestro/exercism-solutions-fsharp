module Anagram

let findAnagrams (sources: string list) (target: string) =
    let symbols =
        target.ToLower()
        |> Seq.sort
        |> Seq.toList

    let isAnagram (candidate: string) =
        not <| System.String.Equals(candidate, target, System.StringComparison.OrdinalIgnoreCase)
        && candidate.ToLower()
           |> Seq.sort
           |> Seq.toList = symbols

    Seq.filter isAnagram sources |> Seq.toList

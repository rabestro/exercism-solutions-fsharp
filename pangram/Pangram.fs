module Pangram

let totalAlphabetCount = 1 + int ('Z' - 'A')
let isPangram (input: string): bool =
    input
    |> Seq.filter System.Char.IsAsciiLetter
    |> Seq.map System.Char.ToUpper
    |> Seq.distinct
    |> Seq.truncate totalAlphabetCount
    |> Seq.length = totalAlphabetCount

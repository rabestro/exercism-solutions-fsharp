module SqueakyClean

open System

let transform (c: char) : string =
    match c with
    | '-' -> "_"
    | ' ' -> ""
    | _ when Char.IsUpper c -> $"-{Char.ToLower c}"
    | _ when Char.IsDigit c -> ""
    | _ when c >= 'α' && c <= 'ω' -> "?"
    | _ -> $"{c}"

let clean (identifier: string): string =
    String.collect transform identifier

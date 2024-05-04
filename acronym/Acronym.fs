module Acronym

open System

let abbreviate (phrase: string) =
    phrase.Split([| ' '; '-'; '_' |], StringSplitOptions.RemoveEmptyEntries)
    |> Array.map (Seq.head >> Char.ToUpper)
    |> String

module OcrNumbers

open System

let [<Literal>] digitHeight = 4
let [<Literal>] digitWidth = 3
let convertDigit =
    function
    | " _ | ||_|   " -> "0"
    | "     |  |   " -> "1"
    | " _  _||_    " -> "2"
    | " _  _| _|   " -> "3"
    | "   |_|  |   " -> "4"
    | " _ |_  _|   " -> "5"
    | " _ |_ |_|   " -> "6"
    | " _   |  |   " -> "7"
    | " _ |_||_|   " -> "8"
    | " _ |_| _|   " -> "9"
    | _ -> "?"

let convertLine (input: string list) =
    let box i =
        seq { 0 .. 3 }
        |> Seq.map (fun l -> input.[l].Substring(i, digitWidth))
        |> String.Concat

    seq { 0 .. digitWidth .. input.[0].Length - 1 }
    |> Seq.map box
    |> Seq.map convertDigit
    |> String.Concat

let convertPage = 
    List.chunkBySize digitHeight
    >> List.map convertLine
    >> String.concat ","

let incorrectSize (input: string list) =
    input.Length % digitHeight <> 0
    || input |> Seq.exists (fun x -> x.Length % digitWidth <> 0)

let convert =
    function
    | input when incorrectSize input -> None
    | input -> convertPage input |> Some

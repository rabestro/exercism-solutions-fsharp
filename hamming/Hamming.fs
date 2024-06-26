module Hamming

let distance (strand1: string) (strand2: string): int option =
    if strand1.Length <> strand2.Length then
        None
    else
        Seq.zip strand1 strand2
        |> Seq.filter (fun x -> fst x <> snd x)
        |> Seq.length
        |> Some

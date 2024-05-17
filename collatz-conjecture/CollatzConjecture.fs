module CollatzConjecture

let (|Even|Odd|) (number: uint64) =
    match number % 2UL with
    | 0UL -> Even
    | _ -> Odd

let steps number: int option =
    let next (number: uint64) =
        match number with
        | Even -> number / 2UL
        | Odd -> 3UL * number + 1UL

    let rec countStepsFor (number: uint64): int =
        match number with
        | 1UL -> 0
        | _ -> 1 + countStepsFor (next number)

    if number < 1 then None else Some <| countStepsFor (uint64 number)

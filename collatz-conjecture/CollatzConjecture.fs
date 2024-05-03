module CollatzConjecture
let (|Even|Odd|) number =
    match number % 2 with
    | 0 -> Even
    | _ -> Odd
    
let steps (number: int): int option =
    
    let next number =
        match number with
        | Even -> number / 2
        | Odd -> 3 * number + 1
    
    let rec countStepsFor number : int =
        if number < 2
        then 0
        else 1 + countStepsFor (next number)
    
    if number < 1
    then None
    else Some <| countStepsFor number

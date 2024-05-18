module CollatzConjecture

let (|Even|Odd|) number =
     match number &&& 1UL with
     | 1UL -> Odd
     | _ -> Even
     
let private next number =
    match number with
    | Odd -> 3UL * number + 1UL
    | Even -> number / 2UL

let private countSteps number =
    let mutable current = (uint64 number)
    let mutable count = 0
    while current > 1UL do
        count <- count + 1
        current <- next current
    count

let private verify number =
    if number < 1 then None else Some number

let steps number: int option = verify number |> Option.map countSteps

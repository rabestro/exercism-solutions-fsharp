module CollatzConjecture

let rec steps (number: int): int option =
    let isEven number = number % 2 = 0
    let next number =
        if isEven number then number / 2
        else 3 * number + 1
    
    let rec countStepsFor number : int =
        if number < 2 then 0
        else 1 + countStepsFor (next number)
    
    if number < 1 then None
    else Some <| countStepsFor number

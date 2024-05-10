module PhoneNumber

open System

let validateNumber (number:string) =
    match number with
    | _ when number[0] = '0' -> Error "area code cannot start with zero"
    | _ when number[0] = '1' -> Error "area code cannot start with one"
    | _ when number[3] = '0' -> Error "exchange code cannot start with zero"
    | _ when number[3] = '1' -> Error "exchange code cannot start with one"
    | _ ->  number |> uint64 |> Ok
    
let validateLength (digits:string) =
    match digits.Length with
    | length when length > 11 -> Error "more than 11 digits"
    | 11 when digits[0] <> '1' -> Error "11 digits must start with 1"
    | 10 -> Ok digits
    | 11 -> Ok digits[1..]
    | _ -> Error "incorrect number of digits"
        
let keepDigits input = input |> Seq.filter Char.IsDigit |> String.Concat

let isPunctuation (symbol:char) = ",:;".Contains symbol
    
let validate input =
    match input with
    | _ when Seq.exists Char.IsLetter input -> Error "letters not permitted"
    | _ when Seq.exists isPunctuation input -> Error "punctuations not permitted"
    | _ -> keepDigits input |> Ok 
    
let clean input =
    validate input
    |> Result.bind validateLength
    |> Result.bind validateNumber

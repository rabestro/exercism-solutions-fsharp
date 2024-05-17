module PhoneNumber

open System

type private Code =
    | Area = 0
    | Exchange = 3
    
let private validateCode code (number:string) =
    let codeName = code.ToString().ToLower()
    match number[int code] with
    | '0' -> Error $"{codeName} code cannot start with zero"
    | '1' -> Error $"{codeName} code cannot start with one"
    | _ -> Ok number
   
let private validateLength (digits:string) =
    match digits.Length with
    | length when length > 11 -> Error "more than 11 digits"
    | 11 when digits[0] <> '1' -> Error "11 digits must start with 1"
    | 11 -> Ok digits[1..]
    | 10 -> Ok digits
    | _ -> Error "incorrect number of digits"
        
let private keepDigits input = input |> Seq.filter Char.IsDigit |> String.Concat

let private isPunctuation (symbol:char) =
      not <| ".()-".Contains symbol && (Char.IsPunctuation symbol)
    
let private validateSymbols input =
    match input with
    | _ when Seq.exists Char.IsLetter input -> Error "letters not permitted"
    | _ when Seq.exists isPunctuation input -> Error "punctuations not permitted"
    | _ -> keepDigits input |> Ok 
    
let clean input =
    input
    |> validateSymbols 
    |> Result.bind validateLength
    |> Result.bind (validateCode Code.Area)
    |> Result.bind (validateCode Code.Exchange)
    |> Result.map UInt64.Parse

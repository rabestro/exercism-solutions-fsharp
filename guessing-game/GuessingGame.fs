module GuessingGame

let reply (guess: int): string =
    match guess with
    | 42 -> "Correct"
    | 41 | 43 -> "So close"
    | _ when guess < 42 -> "Too low"
    | _ -> "Too high"

module TwoFer

let twoFer (input: string option): string =
    let name = Option.defaultValue "you" input
    $"One for {name}, one for me."
    
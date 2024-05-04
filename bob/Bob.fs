module Bob

let response (input: string): string =
    let phrase = input.Trim()
    let silence = phrase = ""
    let question = phrase.EndsWith "?"
    let yelling = phrase.ToUpper() = phrase && phrase.ToLower() <> phrase
    
    match (silence, question, yelling) with
    | _ when silence -> "Fine. Be that way!"
    | _ when yelling && question -> "Calm down, I know what I'm doing!"
    | _ when yelling -> "Whoa, chill out!"
    | _ when question -> "Sure."
    | _ -> "Whatever."

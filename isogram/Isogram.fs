module Isogram

open System.Text.RegularExpressions

let repeatingLetter = Regex("(\p{L}).*?\1", RegexOptions.IgnoreCase)
let isIsogram (phrase: string): bool = not <| repeatingLetter.IsMatch phrase

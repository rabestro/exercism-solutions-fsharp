module PigLatin

open System.Text.RegularExpressions

let PigLatinFormat = "${base}${consonants}ay"

let WordPattern = Regex("""
    (?<consonants>                    # Capture group for possible consonants at the start of a word
        (?!xr|yt)                     # Look ahead negative. Consonants should not start with "xr" or "yt"
        y?                            # Allows optional 'y' at start,
        (qu|[bcdfghjklmnpqrstvwxz])*  # ... then 'qu' or any consonant except 'y'
    )?                                # The entire consonant group is optional (for words starting with vowels)
    (?<base>\w+)                      # Capture group for the base of the word (remaining letters)
    """, RegexOptions.Compiled + RegexOptions.IgnorePatternWhitespace + RegexOptions.IgnoreCase)

let translate input = WordPattern.Replace(input, PigLatinFormat)

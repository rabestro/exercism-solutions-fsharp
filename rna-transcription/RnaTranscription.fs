module RnaTranscription

let toRna (dna: string): string =
    let transcription = function
        | 'G' -> 'C'
        | 'C' -> 'G'
        | 'T' -> 'A'
        | 'A' -> 'U'
        | other -> other

    dna |> String.map transcription
module ProteinTranslation

let toPolypeptide =
    function
    | "AUG" -> "Methionine"
    | "UUC"
    | "UUU" -> "Phenylalanine"
    | "UUA"
    | "UUG" -> "Leucine"
    | "UCU"
    | "UCC"
    | "UCA"
    | "UCG" -> "Serine"
    | "UAU"
    | "UAC" -> "Tyrosine"
    | "UGC"
    | "UGU" -> "Cysteine"
    | "UGG" -> "Tryptophan"
    | _ -> "STOP"

let proteins (rna: string) =
    Seq.chunkBySize 3 rna
    |> Seq.map (System.String >> toPolypeptide)
    |> Seq.takeWhile ((<>) "STOP")
    |> Seq.toList

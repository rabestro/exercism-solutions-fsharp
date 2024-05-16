module LargestSeriesProduct

open System


let largestProduct (input: string) seriesLength: int option =
    let isValidInput() = Seq.forall Char.IsDigit input && input.Length > 0
    let isValidSpan() = seriesLength > 0 && seriesLength <= input.Length

    let product digits =
        digits
        |> Seq.map Char.GetNumericValue
        |> Seq.map int
        |> Seq.reduce (*)

    let calculateLargestProduct() =
        input
        |> Seq.windowed seriesLength
        |> Seq.map product
        |> Seq.max
        |> Some

    if isValidInput() && isValidSpan() then calculateLargestProduct() else None

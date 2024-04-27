module ArmstrongNumbers

open System.Globalization

let isArmstrongNumber (number: int): bool =
    let digits = string number |> Seq.map CharUnicodeInfo.GetDigitValue |> Seq.toArray
    let length = digits.Length
    let armstrongSum = digits |> Array.sumBy (fun d -> float d ** length)
    armstrongSum = number
module LargestSeriesProductTests

open FsUnit.Xunit
open Xunit

open LargestSeriesProduct

[<Fact>]
let ``Finds the largest product if span equals length`` () =
    let digits = "29"
    let span = 2
    largestProduct digits span |> should equal (Some 18)

[<Fact>]
let ``Can find the largest product of 2 with numbers in order`` () =
    let digits = "0123456789"
    let span = 2
    largestProduct digits span |> should equal (Some 72)

[<Fact>]
let ``Can find the largest product of 2`` () =
    let digits = "576802143"
    let span = 2
    largestProduct digits span |> should equal (Some 48)

[<Fact>]
let ``Can find the largest product of 3 with numbers in order`` () =
    let digits = "0123456789"
    let span = 3
    largestProduct digits span |> should equal (Some 504)

[<Fact>]
let ``Can find the largest product of 3`` () =
    let digits = "1027839564"
    let span = 3
    largestProduct digits span |> should equal (Some 270)

[<Fact>]
let ``Can find the largest product of 5 with numbers in order`` () =
    let digits = "0123456789"
    let span = 5
    largestProduct digits span |> should equal (Some 15120)

[<Fact>]
let ``Can get the largest product of a big number`` () =
    let digits = "73167176531330624919225119674426574742355349194934"
    let span = 6
    largestProduct digits span |> should equal (Some 23520)

[<Fact>]
let ``Reports zero if the only digits are zero`` () =
    let digits = "0000"
    let span = 2
    largestProduct digits span |> should equal (Some 0)

[<Fact>]
let ``Reports zero if all spans include zero`` () =
    let digits = "99099"
    let span = 3
    largestProduct digits span |> should equal (Some 0)

[<Fact>]
let ``Rejects span longer than string length`` () =
    let digits = "123"
    let span = 4
    largestProduct digits span |> should equal None

[<Fact>]
let ``Rejects empty string and nonzero span`` () =
    let digits = ""
    let span = 1
    largestProduct digits span |> should equal None

[<Fact>]
let ``Rejects invalid character in digits`` () =
    let digits = "1234a5"
    let span = 2
    largestProduct digits span |> should equal None

[<Fact>]
let ``Rejects negative span`` () =
    let digits = "12345"
    let span = -1
    largestProduct digits span |> should equal None


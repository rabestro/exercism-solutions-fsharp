module Darts

let [<Literal>] OuterRadius  = 10
let [<Literal>] MiddleRadius = 5
let [<Literal>] InnerRadius  = 1

let score (x: double) (y: double): int =
    let distance = x * x + y * y |> sqrt
    match distance with
    | _ when distance <= InnerRadius -> 10
    | _ when distance <= MiddleRadius -> 5
    | _ when distance <= OuterRadius -> 1
    | _ -> 0

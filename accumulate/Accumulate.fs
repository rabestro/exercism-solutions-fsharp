module Accumulate

let accumulate (func: 'a -> 'b) (input: 'a list): 'b list = input |> List.map func

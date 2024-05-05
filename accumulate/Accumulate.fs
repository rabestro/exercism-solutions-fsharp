module Accumulate

let accumulate (func: 'a -> 'b) (input: 'a list): 'b list = List.map func input

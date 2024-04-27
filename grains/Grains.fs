module Grains

let square (n: int): Result<uint64,string> =
    if n >= 1 && n <= 64 then 1UL <<< n - 1 |> Ok
    else Error "square must be between 1 and 64"
    
let total: Result<uint64,string> = Ok ~~~0UL
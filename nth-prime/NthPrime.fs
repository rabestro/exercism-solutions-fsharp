module NthPrime

let calculatePrime nth =
    let primes = ResizeArray<int>([ 2 ])
    
    let isPrime number =
        primes
        |> Seq.takeWhile (fun p -> p * p <= number)
        |> Seq.exists (fun p -> number % p = 0)
        |> not

    seq { 3 .. 2 .. System.Int32.MaxValue }
    |> Seq.takeWhile (fun _ -> primes.Count < nth)
    |> Seq.filter isPrime
    |> Seq.iter primes.Add

    primes.Item(nth - 1)

let prime nth: int option =
    if nth < 1 then None else Some <| calculatePrime nth

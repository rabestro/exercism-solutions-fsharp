module ErrorHandling

let handleErrorByThrowingException() = failwith "Some exception"

let handleErrorByReturningOption (input: string) =
    try
        int input |> Some
    with _ -> None

let handleErrorByReturningResult (input: string) =
    try
        int input |> Ok
    with _ -> Error "Could not convert input to integer"

let bind switchFunction twoTrackInput = twoTrackInput |> Result.bind switchFunction

let cleanupDisposablesWhenThrowingException resource =
    use _ = resource
    failwith "Some exception"

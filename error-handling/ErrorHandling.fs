module ErrorHandling

let handleErrorByThrowingException() = (failwith "Some exception")

let handleErrorByReturningOption input =
    try
        int input |> Some
    with _ -> None

let handleErrorByReturningResult input =
    try
        int input |> Ok
    with _ -> Error "Could not convert input to integer"

let bind switchFunction twoTrackInput =
    match twoTrackInput with
    | Ok x -> switchFunction x
    | error -> error

let cleanupDisposablesWhenThrowingException (resource: System.IDisposable) =
    try
        failwith "Some exception"
    finally
        resource.Dispose()

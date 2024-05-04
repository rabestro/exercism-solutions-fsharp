module BirdWatcher

let lastWeek: int[] = [| 0; 2; 5; 3; 7; 8; 4 |]

let yesterday (counts: int[]) : int = counts[5]

let total (counts: int[]) : int = Array.sum counts

let dayWithoutBirds (counts: int[]) : bool = Array.contains 0 counts

let incrementTodaysCount (counts: int[]) : int[] =
    let today = 6
    counts[today] <- counts[today] + 1
    counts

let unusualWeek (counts: int[]) : bool =
    match counts with
    | [| _; 0; _; 0; _; 0; _ |]
    | [| _; 10; _; 10; _; 10; _ |]
    | [| 5; _; 5; _; 5; _; 5 |] -> true
    | _ -> false

module Raindrops

let convert (number: int): string =
    let sound (divider, word) =
        if number % divider = 0 then Some word else None
    [ 3, "Pling"; 5, "Plang"; 7, "Plong" ]
    |> List.map sound
    |> List.choose id
    |> function
    | [] -> string number
    | sounds -> String.concat "" sounds

module Raindrops

let convert (number: int): string =
    [ if number % 3 = 0 then Some "Pling" else None
      if number % 5 = 0 then Some "Plang" else None
      if number % 7 = 0 then Some "Plong" else None ]
    |> List.choose id
    |> function
    | [] -> string number
    | sounds -> String.concat "" sounds

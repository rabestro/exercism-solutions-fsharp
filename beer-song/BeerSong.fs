module BeerSong

let verse =
    function
    | 0 -> ["No more bottles of beer on the wall, no more bottles of beer."
            "Go to the store and buy some more, 99 bottles of beer on the wall."]
    | 1 -> ["1 bottle of beer on the wall, 1 bottle of beer."
            "Take it down and pass it around, no more bottles of beer on the wall."]
    | 2 -> ["2 bottles of beer on the wall, 2 bottles of beer."
            "Take one down and pass it around, 1 bottle of beer on the wall."]
    | i -> [$"{i} bottles of beer on the wall, {i} bottles of beer."
            $"Take one down and pass it around, {i - 1} bottles of beer on the wall."]
    
let recite (startBottles: int) (takeDown: int) =
    let endBottles = startBottles - takeDown + 1
    { startBottles .. -1 .. endBottles}
    |> Seq.collect (fun n -> verse n @ if n > endBottles then [""] else [])
    |> Seq.toList
        
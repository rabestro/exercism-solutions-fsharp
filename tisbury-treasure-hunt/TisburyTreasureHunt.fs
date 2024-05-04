module TisburyTreasureHunt

open System

let getCoordinate (line: string * string) : string = snd line

let convertCoordinate (coordinate: string) : int * char = (int coordinate[0] - 48, coordinate[1])

let compareRecords (azarasData: string * string) (ruisData: string * (int * char) * string) : bool =
    let azarasCoordinates = getCoordinate >> convertCoordinate <| azarasData
    let _, ruisCoordinates, _ = ruisData
    azarasCoordinates = ruisCoordinates

let createRecord
    (azarasData: string * string)
    (ruisData: string * (int * char) * string)
    : (string * string * string * string) =

    if compareRecords azarasData ruisData then
        let treasure, coordinate = azarasData
        let location, _, quadrant = ruisData
        (coordinate, location, quadrant, treasure)
    else
        ("", "", "", "")

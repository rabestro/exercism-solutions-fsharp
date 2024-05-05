module KindergartenGarden

type Plant =
    | Grass
    | Clover
    | Radishes
    | Violets

let toPlant symbol =
    match symbol with
    | 'G' -> Grass
    | 'C' -> Clover
    | 'R' -> Radishes
    | 'V' -> Violets
    | _ -> failwith $"Unknown symbol '{symbol}'"
    
let plants (diagram: string) (student:string) =
    let startIndex = 2 * int (student[ 0 ] - 'A')
    
    diagram.Split('\n')
    |> Seq.map _.Substring(startIndex, 2)
    |> String.concat ""
    |> Seq.map toPlant
    |> Seq.toList


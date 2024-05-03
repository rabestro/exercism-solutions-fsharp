module ValentinesDay

type Approval = Yes | No | Maybe
type Cuisine = Korean | Turkish

type Genre =
    | Crime
    | Horror
    | Romance
    | Thriller

type Activity = 
    | BoardGame
    | Chill
    | Movie of Genre
    | Restaurant of Cuisine
    | Walk of int

let rateActivity (activity: Activity): Approval = 
    match activity with 
    | Movie Romance -> Yes
    | Restaurant Korean -> Yes
    | Restaurant Turkish -> Maybe
    | Walk distance when distance <= 2 -> Yes
    | Walk distance when distance <= 4 -> Maybe
    | _ -> No

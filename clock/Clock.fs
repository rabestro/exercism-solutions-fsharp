module Clock

[<Literal>]
let private minutesPerHour = 60
[<Literal>]
let private hoursPerDay = 24
[<Literal>]
let private minutesPerDay = minutesPerHour * hoursPerDay

type Clock = Clock of Minutes:int

let normalize minutes =
    let rawMinutes = minutes % minutesPerDay
    if rawMinutes < 0
    then rawMinutes + minutesPerDay
    else rawMinutes

let create hours minutes =
    let totalMinutes = normalize <| hours * minutesPerHour + minutes
    Clock totalMinutes

let add minutes (Clock totalMinutes) = create 0 <| totalMinutes + minutes

let subtract minutes clock = add -minutes clock

let display (Clock totalMinutes) =
    let hours = totalMinutes / minutesPerHour
    let minutes = totalMinutes % minutesPerHour
    $"%02d{hours}:%02d{minutes}"

module Clock

[<Literal>]
let private minutesPerHour = 60
[<Literal>]
let private hoursPerDay = 24
[<Literal>]
let private minutesPerDay = minutesPerHour * hoursPerDay

type Clock = Clock of Minutes:int

let normalize minutes = (minutes % minutesPerDay + minutesPerDay) % minutesPerDay

let create hours minutes = Clock (normalize <| hours * minutesPerHour + minutes )

let add minutes (Clock totalMinutes) = create 0 (totalMinutes + minutes)

let subtract minutes clock = add -minutes clock

let display (Clock totalMinutes) = $"%02d{totalMinutes / minutesPerHour}:%02d{totalMinutes % minutesPerHour}"

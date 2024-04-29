module Clock

[<Literal>]
let private minutesPerHour = 60
[<Literal>]
let private hoursPerDay = 24

[<Literal>]
let private minutesPerDay = minutesPerHour * hoursPerDay

type Clock =
    { Hours: int
      Minutes: int }

let create hours minutes =
    let mutable h = hours + minutes / minutesPerHour
    let mutable m = minutes % minutesPerHour
    if m < 0 then
        h <- h - 1
        m <- m + minutesPerHour
    h <- h % hoursPerDay
    if h < 0 then h <- h + hoursPerDay

    { Hours = h
      Minutes = m }

let add minutes clock = create clock.Hours (clock.Minutes + minutes)

let subtract minutes clock = create clock.Hours (clock.Minutes - minutes)

let display clock = $"%02d{clock.Hours}:%02d{clock.Minutes}"

module CarsAssemble
let baseProductionRate = 221.0
let minutesInHour = 60.0

let successRate (speed: int): float =
    if speed = 0 then 0.0
    elif speed < 5 then 1.00
    elif speed < 9 then 0.90
    elif speed = 9 then 0.80
    else 0.77

let productionRatePerHour (speed: int): float =
    baseProductionRate * successRate speed * float speed

let workingItemsPerMinute (speed: int): int =
    int <| productionRatePerHour speed / minutesInHour
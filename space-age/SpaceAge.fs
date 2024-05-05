module SpaceAge

type Planet = | Earth | Mercury | Venus | Mars | Jupiter | Saturn | Uranus | Neptune

let rec age (planet: Planet) (seconds: int64): float =
    let earthAge = float seconds / 31557600.0
    let orbitalPeriod = 
        match planet with
        | Mercury -> 0.2408467
        | Venus -> 0.61519726
        | Earth -> 1.0
        | Mars ->  1.8808158
        | Jupiter ->  11.862615
        | Saturn ->  29.447498
        | Uranus ->  84.016846
        | Neptune ->  164.79132
        
    earthAge / orbitalPeriod

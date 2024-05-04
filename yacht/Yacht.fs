module Yacht

type Category =
    | Ones
    | Twos
    | Threes
    | Fours
    | Fives
    | Sixes
    | FullHouse
    | FourOfAKind
    | LittleStraight
    | BigStraight
    | Choice
    | Yacht

type Die =
    | One
    | Two
    | Three
    | Four
    | Five
    | Six

let score category dice =
    let unique =
        dice
        |> Seq.distinct
        |> Seq.length

    let dieNumber die =
        match die with
        | One -> 1
        | Two -> 2
        | Three -> 3
        | Four -> 4
        | Five -> 5
        | Six -> 6

    let dieScore die =
        dice
        |> Seq.where (fun x -> x = die)
        |> Seq.length
        |> (*) (dieNumber die)

    let firstDieCount =
        dice
        |> Seq.where (fun x -> x = Seq.head dice)
        |> Seq.length

    let diceSum dice =
        dice
        |> Seq.map dieNumber
        |> Seq.sum

    let hasOne = dice |> Seq.contains One
    let hasSix = dice |> Seq.contains Six

    match category with
    | Yacht ->
        if unique = 1 then 50 else 0
    | Ones -> dieScore One
    | Twos -> dieScore Two
    | Threes -> dieScore Three
    | Fours -> dieScore Four
    | Fives -> dieScore Five
    | Sixes -> dieScore Six
    | Choice -> diceSum dice
    | LittleStraight ->
        if unique = 5 && hasOne && not hasSix then 30 else 0
    | BigStraight ->
        if unique = 5 && hasSix && not hasOne then 30 else 0
    | FullHouse ->
        if unique = 2 && (firstDieCount = 2 || firstDieCount = 3)
        then diceSum dice
        else 0
    | FourOfAKind ->
        if unique < 3 && (firstDieCount = 1 || firstDieCount = 4 || firstDieCount = 5) then
            if firstDieCount = 1
            then diceSum dice - dieNumber (Seq.head dice)
            else 4 * dieNumber (Seq.head dice)
        else
            0

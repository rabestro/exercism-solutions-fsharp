module Meetup

open System

type Week =
    | First
    | Second
    | Third
    | Fourth
    | Last
    | Teenth

let meetup year month week dayOfWeek: DateTime =
    match week with
    | First -> seq { 1 .. 7 }
    | Second -> seq { 8 .. 14 }
    | Third -> seq { 15 .. 21 }
    | Fourth -> seq { 22 .. 28 }
    | Last ->
        let lastDay = DateTime.DaysInMonth(year, month)
        seq { lastDay - 6 .. lastDay }
    | Teenth -> seq { 13 .. 19 }
    |> Seq.map (fun day -> DateTime(year, month, day))
    |> Seq.find (fun date -> date.DayOfWeek = dayOfWeek)

module TwelveDays

let giftOnDay =
    [ ("first", "a Partridge in a Pear Tree")
      ("second", "two Turtle Doves, and")
      ("third", "three French Hens,")
      ("fourth", "four Calling Birds,")
      ("fifth", "five Gold Rings,")
      ("sixth", "six Geese-a-Laying,")
      ("seventh", "seven Swans-a-Swimming,")
      ("eighth", "eight Maids-a-Milking,")
      ("ninth", "nine Ladies Dancing,")
      ("tenth", "ten Lords-a-Leaping,")
      ("eleventh", "eleven Pipers Piping,")
      ("twelfth", "twelve Drummers Drumming,") ]

let verse number =
    let day, _ = giftOnDay[number - 1]
    let gifts = giftOnDay |> Seq.take number |> Seq.map snd |> Seq.rev |> String.concat " "
    $"On the {day} day of Christmas my true love gave to me: {gifts}."
    
let recite start stop =
    seq {start .. stop} |> Seq.map verse |> Seq.toList

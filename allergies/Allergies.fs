module Allergies

type Allergen =
    | Eggs = 1
    | Peanuts = 2
    | Shellfish = 4
    | Strawberries = 8
    | Tomatoes = 16
    | Chocolate = 32
    | Pollen = 64
    | Cats = 128

let allergicTo codedAllergies allergen = codedAllergies &&& int allergen <> 0

let list codedAllergies =
    System.Enum.GetValues<Allergen>()
    |> Seq.filter (allergicTo codedAllergies)
    |> Seq.toList

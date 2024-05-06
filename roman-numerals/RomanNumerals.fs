module RomanNumerals

let roman arabicNumeral =
    let thousands = arabicNumeral / 1000
    let hundreds = arabicNumeral % 1000 / 100
    let tens = arabicNumeral % 100 / 10
    let units = arabicNumeral % 10
    
    [ ""; "M"; "MM"; "MMM" ].[thousands]
    + [ ""; "C"; "CC"; "CCC"; "CD"; "D"; "DC"; "DCC"; "DCCC"; "CM" ].[hundreds]
    + [ ""; "X"; "XX"; "XXX"; "XL"; "L"; "LX"; "LXX"; "LXXX"; "XC" ].[tens]
    + [ ""; "I"; "II"; "III"; "IV"; "V"; "VI"; "VII"; "VIII"; "IX" ].[units]

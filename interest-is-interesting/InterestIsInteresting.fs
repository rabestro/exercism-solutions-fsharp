module InterestIsInteresting

let interestRate (balance: decimal): single =
    match balance with
    | _ when balance < 0m -> 3.213f
    | _ when balance < 1000m -> 0.5f
    | _ when balance < 5000m -> 1.621f
    | _ -> 2.475f
    
let interest (balance: decimal): decimal =
   0.01f * interestRate balance |> decimal |> (*) balance 

let annualBalanceUpdate(balance: decimal): decimal =
   balance + interest balance

let amountToDonate(balance: decimal) (taxFreePercentage: float): int =
   if balance > 0m
   then taxFreePercentage / 50. |> decimal |> (*) balance |> int
   else 0

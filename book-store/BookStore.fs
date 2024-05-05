module BookStore

let total books =
    // Initialize an array to hold the counts of each book series
    let series = Array.zeroCreate 5
    
    // Count the occurrences of each book series
    books
    |> Seq.countBy id
    |> Seq.iter (fun (i, count) -> series[i - 1] <- count)
    Array.sortInPlace series
    
    // Calculate the differences between each count and the previous one    
    let calculateDifference i x = 
        if i = 0 then x else x - series[i - 1]
    let groups = Array.mapi calculateDifference series
    
    // Combine groups to maximize the discount
    let combined = min groups[2] groups[0]
    groups[0] <- groups[0] - combined
    groups[2] <- groups[2] - combined
    groups[1] <- groups[1] + combined * 2
    
    // Define the prices for each group size
    let groupPrice = [
        5 * 8 * 75
        4 * 8 * 80
        3 * 8 * 90
        2 * 8 * 95
        1 * 8 * 100
    ]
    let calculatePrice i x = 
        decimal (x * groupPrice[i]) / 100m
        
    // Calculate the total price
    groups |> Array.mapi calculatePrice |> Array.sum
    
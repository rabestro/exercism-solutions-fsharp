module RobotName

let mutable count = 0
    
let mkRobot() = count <- count + 1; count

let name robot =
    let random = System.Random(robot)
    let randomLetter = int 'A' + random.Next(26) |> char
    $"{randomLetter}{randomLetter}%03d{random.Next(1000)}"
    
let reset robot = mkRobot()
module RobotSimulator

type Direction =
    | North
    | East
    | South
    | West

type Position = int * int

type Robot =
    { direction: Direction
      position: Position }

let turnRight robot =
    match robot.direction with
    | North -> East
    | East -> South
    | South -> West
    | West -> North
    |> fun x -> { robot with direction = x }

let turnLeft robot =
    match robot.direction with
    | North -> West
    | East -> North
    | South -> East
    | West -> South
    |> fun x -> { robot with direction = x }

let advance robot =
    match (robot.direction, robot.position) with
    | North, (x, y) -> x, y + 1
    | East, (x, y) -> x + 1, y
    | South, (x, y) -> x, y - 1
    | West, (x, y) -> x - 1, y
    |> fun position -> { robot with position = position }

let act robot instruction =
    match instruction with
    | 'R' -> turnRight robot
    | 'L' -> turnLeft robot
    | _ -> advance robot

let create direction position =
    { direction = direction
      position = position }

let move (instructions: string) robot = Seq.fold act robot instructions

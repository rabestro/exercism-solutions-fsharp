module CircularBuffer

type CircularBuffer<'a> =
    { items: 'a list
      size: int }

type CircularBuffer<'a> with
    member this.isFull() = this.items.Length = this.size
    member this.append value = { this with items = this.items @ [ value ] }
    member this.overwrite value = { this with items = this.items.Tail @ [ value ] }

let mkCircularBuffer size =
    { items = []
      size = size }

let clear buffer = { buffer with items = [] }

let write value (buffer: CircularBuffer<'a>) =
    if buffer.isFull()
    then failwith "Cannot write to full buffer"
    else buffer.append value

let forceWrite value (buffer: CircularBuffer<'a>) =
    if buffer.isFull()
    then buffer.overwrite value
    else buffer.append value

let read buffer =
    match buffer.items with
    | [] -> failwith "Cannot read from empty buffer"
    | x :: xs -> x, { buffer with items = xs }

module CircularBuffer

type CircularBuffer =
    { buffer: int array
      head: int ref
      size: int ref }

type CircularBuffer with
    member this.write data =
        this.buffer[ this.head.Value ] <- data
        this.head.Value <- (this.head.Value + 1) % this.buffer.Length
        this.size.Value <- min (this.size.Value + 1) this.buffer.Length
        this
        
    member this.read() =
        let index = (this.buffer.Length + this.head.Value - this.size.Value) % this.buffer.Length
        this.size.Value <- this.size.Value - 1
        this.buffer[index]

let mkCircularBuffer size =
    { buffer = Array.create size 0
      head = ref 0
      size = ref 0 }

let clear buffer =
    buffer.size.Value <- 0
    buffer

let write value buffer =
    if buffer.size.Value = buffer.buffer.Length
    then failwith "You need to implement this function."
    else buffer.write value

let forceWrite value (buffer: CircularBuffer) = buffer.write value

let read buffer =
    if buffer.size.Value = 0 then
        failwith "Tried to read from empty buffer"
        0, buffer
    else 
        buffer.read(), buffer
module ionz

let fetch_bits high length word =
  let mask = ~~~ (-1 <<< length) in
  (word >>> (high - length + 1)) &&& mask

[<EntryPoint>]
let main argv =
    printfn "%0X" (fetch_bits 15 4 0xFFFF)
    0 // return an integer exit code

open ionz

let fetch_bits (BitIndex high) (BitLength length) word =
  let mask = ~~~ (-1 <<< length) in
  (word >>> (high - length + 1)) &&& mask

[<EntryPoint>]
let main argv =
    printfn "%0X" (fetch_bits bit15 (BitLength 4) 0xFFFF)
    0 // return an integer exit code

module Main

open Ionz
open Bucket

[<EntryPoint>]
let main argv =
    let addr1 = ByteAddress 1
    let bytes_a = Bucket.newBucket [|1uy;2uy;3uy|]
    let bytes_b = Bucket.writeBytes bytes_a addr1 65uy
    let b_a = Bucket.readByte bytes_a addr1 in
    let b_b = Bucket.readByte bytes_b addr1 in
    Printf.printf "%d %d\n" b_a b_b
    printfn "%0X" (fetchBits bit15 (BitLength 4) 0xFFFF)
    0 // return an integer exit code

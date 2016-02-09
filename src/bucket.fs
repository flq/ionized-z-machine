module Bucket

open Ionz

type Bucket = {
  originalBytes: byte array;
  edits: IntMap<byte>;
}

let isInRange (ByteAddress address) size =
    0 <= address && address < size

let isOutOfRange address size =
    not (isInRange address size)

let newBucket bytes = { originalBytes = bytes; edits = Map.empty; }

let size bucket = bucket.originalBytes.Length

let readByte bytes address =
  if isOutOfRange address (size bytes) then
    failwith "address is out of range"
  else
    let (ByteAddress addr) = address
    match Map.tryFind addr bytes.edits with
    | (Some value) -> value
    | None -> bytes.originalBytes.[addr]

let writeBytes bytes address value =
  if isOutOfRange address (size bytes) then
    failwith "address is out of range"
  else
    let (ByteAddress addr) = address
    { bytes with edits = Map.add addr value bytes.edits }

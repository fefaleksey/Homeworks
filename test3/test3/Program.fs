//first sequence
let firstSeq _ = Seq.initInfinite (fun index -> if index % 2 = 0 then 1 else -1)
//second(rezult) sequence
let getRezult _ = 
    let seq = firstSeq()
    Seq.initInfinite (fun index -> (index + 1) * (Seq.item index seq))


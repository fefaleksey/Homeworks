//first sequence
let seqInfinite _ = Seq.initInfinite (fun index -> if index % 2 = 0 then 1 else -1)
//second(rezult) sequence
let getRezult _ = 
    let seq = seqInfinite()
    Seq.initInfinite (fun index -> (index + 1) * (Seq.item index seq))

let r = getRezult()

printfn "%A" seqInfinite
printfn "%A" r//(Seq.take 3 rezult())

open Solve
open task3

[<EntryPoint>]
let main args =
    let newBook = addRecord (new Person("228", "kek")) []
    let newBook1 = addRecord (new Person("229", "shmek")) newBook
    let newBook2 = addRecord (new Person("230", "ll")) newBook1
    let rez = findPhone "shmek" newBook2
    let a = rez.ToString()
    let s1 = "229" = rez.ToString()
    run()
    printfn "%A" (rez.ToString())
    0
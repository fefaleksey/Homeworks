open solve
open task3

[<EntryPoint>]
let main args =
    let newBook = addRecord (new person("228", "kek")) []
    let newBook1 = addRecord (new person("229", "shmek")) newBook
    let newBook2 = addRecord (new person("230", "ll")) newBook1
    let rez = findPhone "shmek" newBook2
    let a = rez.ToString()
    let s1 = "229" = rez.ToString()
    Run()
    printfn "%A" (rez.ToString())
    0
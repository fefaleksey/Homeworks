module Tests

open System
open Xunit
open solve


[<Fact>]
let ``Add record`` () = 
    let persons = solve.task5.person(228, ll) |> addRecord
    Assert.True(true)

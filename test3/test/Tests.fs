module Tests

open Program
open System
open Xunit


[<Fact>]
let ``rezult sequence`` () =
    let rez = Seq.take 5 (getRezult())// |> Seq.toList
    let equal = [1; -2; 3; -4; 5]// |> List.toSeq
    let bl = rez = (List.toSeq equal)
    Assert.Equal(equal, rez)
    
    
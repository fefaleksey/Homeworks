module Tests

open Program
open Xunit

[<Fact>]
let ``rezult sequence`` () =
    let rez = Seq.take 5 (getRezult())
    let equal = [1; -2; 3; -4; 5]
    let bl = rez = (List.toSeq equal)
    Assert.Equal(equal, rez)
    
    
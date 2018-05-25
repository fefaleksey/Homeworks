module Tests

open System
open Xunit
open Program

[<Fact>]
let ``RoundingBuilder test`` () =
    let rounding digit = new RoundingBuilder(digit)
    let res = 
        rounding 3 {
            let! a = 2.0 / 12.0
            let! b = 3.5
            return a / b
        } 
    Assert.Equal(0.048, res)

[<Fact>]
let ``RoundingBuilder test 1`` () =
    
    let maybe = new MaybeBuilder()
    let res = maybe {
            let! x = "1"
            let! y = "Ъ"
            let z = x + y
            return z
    }
    Assert.Equal(None, res)
    
[<Fact>]
let ``RoundingBuilder test 2`` () =    
    let maybe = new MaybeBuilder()
    let res = maybe {
            let! x = "1"
            let! y = "2"
            let z = x + y
            return z
        }
    Assert.Equal(Some 3, res)
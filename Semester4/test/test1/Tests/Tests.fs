module Tests

open System
open Xunit
open solve

[<Fact>]
let ``averageValue for empty list`` () =
    Assert.Equal(double 0, averageValue [])

[<Fact>]
let ``averageValue`` () =
    let a = double 0.5 |> sin
    let b = double 0.2 |> sin
    let c = double 0.8 |> sin
    let d = (a + b + c) / 3.0
    let avg = averageValue [0.5; 0.2; 0.8]
    let avg1 = averageValue [0.5; 0.2; 0.8]
    Assert.Equal(d, averageValue [0.5; 0.2; 0.8])

[<Fact>]
let ``findMinDistance in simple tree`` () =
    let tree = Node(1, Empty, Empty)
    Assert.Equal(0, findMinDistance tree)

[<Fact>]
let ``findMinDistance`` () =
    let tree = Node (1, Node(1, Empty, Empty), Node(2,Empty,Empty))
    Assert.Equal(1, findMinDistance tree)



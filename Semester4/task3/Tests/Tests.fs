module Tests

open System
open Xunit
open task3

[<Fact>]
let ``Test count1`` () =
    Assert.True((solve.count1 [1;2;3;4;5;6]) = 3)

[<Fact>]
let ``Test count2`` () =
    Assert.True((solve.count2 [1;2;3;4;5;6]) = 3)

[<Fact>]
let ``Test count3`` () =
    Assert.True((solve.count3 [1;2;3;4;5;6]) = 3)

[<Fact>]
let ``Test mapTree`` () =
    let tree = 
        solve.Node(4, solve.Node(2,solve.Node(1, solve.Empty,solve.Empty),solve.Node(3,solve.Empty,solve.Empty)),
            solve.Node(6,solve.Node(5, solve.Empty,solve.Empty),solve.Node(7,solve.Empty,solve.Empty)))
    let tree1 = solve.mapTree tree (fun x -> 2 * x)
    Assert.Equal(solve.Node(8, solve.Node(4,solve.Node(2, solve.Empty,solve.Empty),solve.Node(6,solve.Empty,solve.Empty)),
                                    solve.Node(12,solve.Node(10, solve.Empty,solve.Empty),solve.Node(14,solve.Empty,solve.Empty))), tree1)

[<Fact>]
let ``Test calculate (5 - 1) * 2 + 10`` () =
    Assert.True (solve.calculate (solve.Add(solve.Mult(solve.Sub(solve.Value 5, solve.Value 1), solve.Value 2), solve.Value 10)) = 18)

module Tests

open System
open Xunit
open task3
open solve

[<Fact>]
let ``Test calculateUsingMap`` () =
    Assert.True((calculateUsingMap [1;2;3;4;5;6]) = 3)

[<Fact>]
let ``Test calculateUsingFold`` () =
    Assert.True((calculateUsingFold [1;2;3;4;5;6]) = 3)

[<Fact>]
let ``Test calculateUsingFilter`` () =
    Assert.True((calculateUsingFilter [1;2;3;4;5;6]) = 3)

[<Fact>]
let ``Test calculateUsingMap empty`` () =
    Assert.Equal(0, (calculateUsingMap []))

[<Fact>]
let ``Test calculateUsingFold empty`` () =
    Assert.Equal(0, (calculateUsingFold []))

[<Fact>]
let ``Test calculateUsingFilter empty`` () =
    Assert.Equal(0, (calculateUsingFilter []))

[<Fact>]
let ``Test mapTree`` () =
    let tree = 
        Node (4, Node(2, Node (1, Empty, Empty),Node (3,Empty, Empty)),
            Node(6, Node (5, Empty, Empty), Node (7, Empty, Empty)))
    let tree1 = mapTree tree (fun x -> 2 * x)
    Assert.Equal (tree1, Node(8, Node(4, Node (2, Empty, Empty), Node (6, Empty, Empty)),
                                    Node(12, Node (10, Empty, Empty), Node (14, Empty, Empty))))

[<Fact>]
let ``Test mapTree empty`` () =
    let tree = Empty
    let tree1 = mapTree tree (fun x -> 2 * x)
    Assert.Equal (Empty, tree1)

//(5 - 1) * 2 + 10
[<Fact>]
let ``Test calculate example`` () =
    Assert.Equal (18, calculate (Add(Mult(Sub(Value 5, Value 1), Value 2), Value 10)))

[<Fact>]
let ``Test calculate empty operationTree`` () =
    Assert.Equal (0, calculate (Null))

[<Fact>]
let ``Test sequence`` () =
    let (^<|) = (<|)
    let kek = [2;3;5;7;11;13;17;19;23;29]
    let shmek = List.ofSeq ^<| Seq.take 10 ^<| generateSequence()
    let bl = kek = shmek
    Assert.True (bl)

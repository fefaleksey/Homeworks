module Tests

open System
open Xunit
open task3
open solve

[<Fact>]
let ``Test count1`` () =
    Assert.True((count1 [1;2;3;4;5;6]) = 3)

[<Fact>]
let ``Test count2`` () =
    Assert.True((count2 [1;2;3;4;5;6]) = 3)

[<Fact>]
let ``Test count3`` () =
    Assert.True((count3 [1;2;3;4;5;6]) = 3)

[<Fact>]
let ``Test count1 empty`` () =
    Assert.Equal(0, (count3 []))

[<Fact>]
let ``Test count2 empty`` () =
    Assert.Equal(0, (count3 []))

[<Fact>]
let ``Test count3 empty`` () =
    Assert.Equal(0, (count3 []))

[<Fact>]
let ``Test mapTree`` () =
    let tree = 
        Node (4, Node(2, Node (1, Empty, Empty),Node (3,Empty, Empty)),
            Node(6, Node (5, Empty, Empty), Node (7, Empty, Empty)))
    let tree1 = mapTree tree (fun x -> 2 * x)
    Assert.Equal (tree1, Node(8, Node(4, Node (2, Empty, Empty), Node (6, Empty, Empty)),
                                    Node(12, Node (10, Empty, Empty), Node (14, Empty, Empty))))

//(5 - 1) * 2 + 10
[<Fact>]
let ``Test calculate example`` () =
    Assert.Equal (18, calculate (Add(Mult(Sub(Value 5, Value 1), Value 2), Value 10)))


[<Fact>]
let ``Test sequence`` () =
    let (^<|) = (<|)
    let kek = [2;3;5;7;11;13;17;19;23;29]
    let shmek = List.ofSeq ^<| Seq.take 10 ^<| generateSequence()
    let bl = kek = shmek
    Assert.True (bl)

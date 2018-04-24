module Tests

open System
open Xunit
open test2

[<Fact>]
let ``supermap for empty`` () =
    let got = supermap [] [cos]
    Assert.True([] = got)

[<Fact>]
let ``supermap non trivial`` () =
    let got = supermap [1.0; 2.0] [cos; sin]
    let expext = [cos(1.0); sin(1.0); cos(2.0); sin(2.0)];
    let rez = expext = got
    Assert.True(rez)
        
[<Fact>]
let ``queue construct`` () =
    let queue = Queue([10], [1])
    let expect = 10 :> IComparable
    let max = queue.GetMaxPriorityElement
    Assert.Equal(expect, max)
    
[<Fact>]
let ``queue add`` () =
    let queue = Queue([], [])
    let queue1 = queue.Add 10 1
    let expect = 10 :> IComparable
    let max = queue1.GetMaxPriorityElement
    Assert.Equal(expect, max)

[<Fact>]
let ``queue get non trivial`` () =
    let queue = Queue([10; 5; 8], [1; 3; 2])
    let expect = 5 :> IComparable
    let max = queue.GetMaxPriorityElement
    Assert.Equal(expect, max)
    let queue1 = queue.Add 10 4
    let expect1 = 10 :> IComparable
    let max1 = queue1.GetMaxPriorityElement
    Assert.Equal(expect1, max1)
    
[<Fact>]
let ``queue delete`` () =
    let queue = Queue([10; 5; 8], [1; 3; 2])
    let expect = 8 :> IComparable
    let queue1 = queue.DeleteMaxPriorityElement
    let value = queue1.GetMaxPriorityElement
    Assert.Equal(expect, value)
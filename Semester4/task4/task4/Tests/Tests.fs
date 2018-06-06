module Tests

open System
open Xunit
open Program

[<Fact>]
let ``getFvList simple if there is`` () = 
    let expected = ['x']
    let actual = getFvList (Variable ('x'))
    let kek = expected = actual
    Assert.True(kek)

[<Fact>]
let ``getFvList simple if there isn't`` () = 
    let expected = ['x']
    let actual = getFvList (Variable ('y'))
    let kek = expected = actual
    Assert.False(kek)
    
[<Fact>]
let ``getFvList non trivial 1`` () = 
    let expected = ['x'; 'y']
    let actual = getFvList (Application (Variable ('x'), Variable ('y')))
    let kek = expected = actual
    Assert.True(kek)
    
[<Fact>]
let ``getFvList non trivial 2`` () = 
    let expected = ['x']
    let actual = getFvList (Abstraction ('y', Variable ('x')))
    let kek = expected = actual
    Assert.True(kek)

[<Fact>]
let ``getFvList non trivial 3`` () = 
    let actual = getFvList (Abstraction ('x', Variable ('x')))
    Assert.True(actual.IsEmpty)

[<Fact>]
let ``getFvList hard test 1`` () = 
    let expected = ['z'; 'n']
    let actual = getFvList (Application (Abstraction ('x', Variable ('z')), Abstraction ('y', Variable ('n'))))
    let kek = expected = actual
    Assert.True(kek)

[<Fact>]
let ``getFvList hard test 2`` () = 
    let expected = ['b']
    let actual = getFvList (Application (Abstraction ('x', Variable ('x')), Abstraction ('a', Variable ('b'))))
    let kek = expected = actual
    Assert.True(kek)

[<Fact>]
let ``getFvList hard test 3`` () = 
    let expected = []
    let actual = getFvList (Application (Abstraction ('x', Variable ('x')), Abstraction ('a', Variable ('a'))))
    Assert.True(actual.IsEmpty)

[<Fact>]
let ``substitution test 1`` () = 
    let expected = (Variable ('z'))
    let actual = substitute (Variable ('z')) ('y') (Variable ('x'))
    let kek = expected = actual
    Assert.True(kek)

[<Fact>]
let ``substitution test 2`` () = 
    let S = Abstraction ('a', Variable ('y'))
    let T = Abstraction ('a', Application (Variable ('a'), Variable ('a')))
    let actual = substitute S 'a' T
    let expected = Abstraction ('a', Variable ('y'))
    let kek = expected = actual
    Assert.True(kek)

[<Fact>]
let ``substitution test 3`` () = 
    let S = Abstraction ('y', Variable ('x'))
    let T = Abstraction ('s', Variable ('y'))
    let actual = substitute S 'x' T
    let expected = Abstraction ('a', Abstraction ('s', Variable ('y')))
    let kek = expected = actual
    Assert.True(kek)
    
//((λa.(λb.b b) (λb.b b)) b) ((λc.(c b)) (λa.a))
[<Fact>]
let ``Homework`` () =
    let actual = betaReduction (Application (Application(Application(Abstraction('a', Abstraction('b', Application(Variable('b'), Variable('b')))), Abstraction('b', Application(Variable('b'), Variable('b')))), Variable('b')), Application(Abstraction('c', Application(Variable('c'), Variable('b'))), Abstraction('a', Variable('a')))))
    let expected = Application (Application (Abstraction (('b'), Application (Variable ('b'), Variable ('b'))), Variable ('b')), Variable ('b'))    
    let kek = expected = actual
    Assert.True(kek)
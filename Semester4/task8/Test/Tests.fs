module Tests

open System
open Xunit
open Program

[<Fact>]
let ``downloadRefPages correctness`` () =
    let res = downloadRefPages "http://hwproj.me/courses/12/terms/1"
    match res with
    | Null -> Assert.True(false)
    | Values(references, results) ->
        let equal = "http://se.math.spbu.ru/SE/SE/programer.doc"
        Assert.Equal(equal, references.[0])
        let equal = "http://se.math.spbu.ru/SE/Members/ylitvinov/styleguide"
        Assert.Equal(equal, references.[1])

[<Fact>]
let ``downloadRefPages counting of symbols`` () =
    let res = downloadRefPages "http://hwproj.me/courses/12/terms/1"
    match res with
    | Null -> Assert.True(false)
    | Values(references, results) ->
        let equal = 472283
        Assert.Equal(equal, results.[0].Length)
        let equal = 22564
        Assert.Equal(equal, results.[1].Length)
module Tests

open System
open System.Collections
open System.Collections.Generic
open Xunit
open solve
open task1
open task2
open task3

[<Fact>]
let ``checkBrackets for empty string`` () =
    Assert.True(checkBrackets "")
    
[<Fact>]
let ``checkBrackets`` () =
    Assert.True(checkBrackets "[sdf]")
    Assert.True(checkBrackets "asd[sad]asd{{asd}a(s)d}")
    Assert.False(checkBrackets "asd[sad]asd{{asd}a(s})d}")

[<Fact>]    
let ``addrecord``() =
    let name = "kek"
    let phoneNumber = "228"
    let person = person(phoneNumber, name)
    let newBook = addRecord person []
    Assert.Equal("kek | 228", newBook.Head.ToString())

[<Fact>]    
let ``findPhoneNumberbyname``() =
    let newBook = addRecord (new person("228", "kek")) []
    let newBook1 = addRecord (new person("229", "shmek")) newBook
    let newBook2 = addRecord (new person("230", "ll")) newBook1
    let rez = findPhone "shmek" newBook2
    let s = String.Compare ("Some(229)", rez.ToString())
    Assert.Equal(0, s)
    
[<Fact>]    
let ``findNameByPhoneNumber``() =
    let newBook = addRecord (new person("228", "kek")) []
    let newBook1 = addRecord (new person("229", "shmek")) newBook
    let newBook2 = addRecord (new person("230", "ll")) newBook1
    let rez = findName "229" newBook2
    let s = String.Compare ("Some(shmek)", rez.ToString())
    Assert.Equal(0, s)
    
[<Fact>]    
let ``save and load records from file``() =
    let newBook = addRecord (new person("228", "kek")) []
    let newBook1 = addRecord (new person("229", "shmek")) newBook
    let newBook2 = addRecord (new person("230", "ll")) newBook1
    
    saveall "test" newBook2
    let loadedRecords = read "test" []
    let s1 = String.Compare ("kek | 228", loadedRecords.[2].ToString())
    Assert.Equal(0, s1)
    let s2 = String.Compare ("shmek | 229", loadedRecords.[1].ToString())
    Assert.Equal(0, s2)
    let s3 = String.Compare ("ll | 230", loadedRecords.[0].ToString())
    Assert.Equal(0, s3)
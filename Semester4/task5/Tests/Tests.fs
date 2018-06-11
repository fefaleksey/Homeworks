module Tests

open System
open System.Collections
open System.Collections.Generic
open Xunit
open FsCheck
open Solve
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
let ``add record in the phone book, after adding head of phone book shall be this record``() =
    let name = "kek"
    let phoneNumber = "228"
    let person = Person(phoneNumber, name)
    let newBook = addRecord person []
    Assert.Equal("kek | 228", newBook.Head.ToString())

[<Fact>]    
let ``find phone number by name in the phone book``() =
    let newBook = addRecord (new Person("228", "kek")) []
    let newBook1 = addRecord (new Person("229", "shmek")) newBook
    let newBook2 = addRecord (new Person("230", "ll")) newBook1
    let rez = findPhone "shmek" newBook2
    let s = String.Compare ("Some(229)", rez.ToString())
    Assert.Equal(0, s)
    
[<Fact>]    
let ``find name by phone number in the phone book``() =
    let newBook = addRecord (new Person("228", "kek")) []
    let newBook1 = addRecord (new Person("229", "shmek")) newBook
    let newBook2 = addRecord (new Person("230", "ll")) newBook1
    let rez = findName "229" newBook2
    let s = String.Compare ("Some(shmek)", rez.ToString())
    Assert.Equal(0, s)
    
[<Fact>]    
let ``save and load records from file, after save and load phone book shall not change``() =
    let newBook = addRecord (new Person("228", "kek")) []
    let newBook1 = addRecord (new Person("229", "shmek")) newBook
    let newBook2 = addRecord (new Person("230", "ll")) newBook1
    
    saveAll "test" newBook2
    let loadedRecords = load "test" []
    let s1 = String.Compare ("kek | 228", loadedRecords.[2].ToString())
    Assert.Equal(0, s1)
    let s2 = String.Compare ("shmek | 229", loadedRecords.[1].ToString())
    Assert.Equal(0, s2)
    let s3 = String.Compare ("ll | 230", loadedRecords.[0].ToString())
    Assert.Equal(0, s3)
    
[<Fact>]
let ``check func and func'1 for equality`` () =
    Check.Quick (fun x l -> func x l = func'1 x l)

[<Fact>]
let ``check func and func'2 for equality`` () =
    Check.Quick (fun x l -> func x l = func'2 x l)

[<Fact>]
let ``check func and func'3 for equality`` () =
    Check.Quick (fun x l -> func x l = func'3 x l)
    
module TestsBinaryTree

open System
open Xunit
open BST
open binaryTree

[<Fact>]
let ``Test_IsExist``() =
    let tree = BinaryTree<int>()
    tree.Add(5)
    tree.Add(3)
    tree.Add(4)
    Assert.True(tree.IsExist(3))

[<Fact>]
let ``Test_Add``() =
    let tree = BinaryTree<int>()
    tree.Add(5)
    tree.Add(3)
    Assert.True(tree.IsExist(3))

[<Fact>]
let ``Test_AddSeveralElements``() =
    let tree = BinaryTree<int>()
    tree.Add(5)
    tree.Add(3)
    tree.Add(6)
    tree.Add(8)
    tree.Add(4)
    tree.Add(1)
    Assert.True(tree.IsExist(3))
    Assert.True(tree.IsExist(6))
    Assert.True(tree.IsExist(8))
    Assert.True(tree.IsExist(4))
    Assert.True(tree.IsExist(1))
    Assert.True(tree.IsExist(5))

[<Fact>]
let ``Test_Delete``() =
    let tree = new BinaryTree<int>()
    tree.Add(5)
    tree.Add(3)
    tree.Add(4)
    tree.Delete(3)
    Assert.True(tree.IsExist(4))

[<Fact>]
let ``Test_DeleteSeveralElements``() =
    let tree = new BinaryTree<int>()
    tree.Add(5)
    tree.Add(3)
    tree.Add(4)
    tree.Delete(3)
    Assert.True(tree.IsExist(4))

[<Fact>]
let ``Test_Foreach``() =
    let tree = new BinaryTree<int>()
    tree.Add(5)
    tree.Add(3)
    tree.Add(4)
    tree.Add(6)
    tree.Add(7)
    let mutable i = 0
    for v in tree do
        i <- i + 1
    Assert.Equal(5, i)

[<Fact>]
let ``Test_DeleteNonTrivial``() =
    let tree = BinaryTree<int>()
    tree.Add(2)
    tree.Add(1)
    tree.Add(6)
    tree.Add(3)
    tree.Add(5)
    tree.Add(4)
    tree.Add(7)
    tree.Delete(6)
    Assert.True(tree.IsExist(4))

[<Fact>]
let ``Test_DeleteNonTrivial1``() =
    let tree = BinaryTree<int>()
    tree.Add(2)
    tree.Add(1)
    tree.Add(6)
    tree.Add(3)
    tree.Add(5)
    tree.Add(4)
    tree.Add(7)
    tree.Delete(6)
    Assert.True(tree.IsExist(4))
    Assert.False(tree.IsExist(6))

[<Fact>]
let ``Test_DeleteNonTrivial2``() =
    let tree = BinaryTree<int>()
    tree.Add(2)
    tree.Add(1)
    tree.Add(6)
    tree.Add(3)
    tree.Add(5)
    tree.Add(4)
    tree.Add(7)
    tree.Delete(6)
    Assert.True(tree.IsExist(4))

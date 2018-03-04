namespace task3 
module solve =
    let count1 list = List.map (fun x -> if x % 2 = 0 then 1 else 0) list |> List.sum
    
    let count2 list = List.fold (fun acc elem -> if elem % 2 = 0 then acc + 1 else acc) 0 list
    
    let count3 list = List.filter (fun x -> x % 2 = 0) list |> List.length
    
    type Tree<'a> = 
        | Empty
        | Node of value: 'a * left: Tree<'a> * right: Tree<'a>
    
    let rec mapTree tree f =
        match tree with
        | Empty -> Empty
        | Node (value, left, right) -> Node (f value, mapTree left f, mapTree right f)
    
    type operationTree =
        | Null
        | Value of Value : int
        | Add of operationTree * operationTree
        | Mult of operationTree * operationTree
        | Div of operationTree * operationTree
        | Sub of operationTree * operationTree
    
    let calculate tree =
        let rec calculate tree =
            match tree with
            | Null -> 0
            | Value a -> a
            | Add (l,r) -> (calculate r) + (calculate l)
            | Mult (l,r) -> (calculate r ) * (calculate l )
            | Div (l,r) -> (calculate r ) / (calculate l )
            | Sub (l,r) -> (calculate l ) - (calculate r )
        calculate tree
    
    let generateSequence _ = 
        let isPrime x = {2..x-1} |> Seq.exists(fun a -> a % x = 0) |> not
        Seq.initInfinite (fun x -> x+2) |> Seq.filter isPrime
    
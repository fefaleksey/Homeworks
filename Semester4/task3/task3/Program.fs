namespace task3 
module solve =
    let calculateUsingMap list = List.map (fun x -> (x + 1) % 2) list |> List.sum
    
    let calculateUsingFold list = List.fold (fun acc elem -> if elem % 2 = 0 then acc + 1 else acc) 0 list
    
    let calculateUsingFilter list = List.filter (fun x -> x % 2 = 0) list |> List.length
    
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
            | Add (l, r) -> (calculate r) + (calculate l)
            | Mult (l, r) -> (calculate r) * (calculate l)
            | Div (l, r) -> (calculate r) / (calculate l)
            | Sub (l, r) -> (calculate l) - (calculate r)
        calculate tree
    
    let generateSequence() : seq<int> =
        let natsFrom2 = Seq.initInfinite (fun x -> x + 2)
        Seq.unfold (fun x -> Some(Seq.head x, Seq.filter (fun el -> el % (Seq.head x) <> 0) <| Seq.tail x)) <| Seq.initInfinite (fun x -> x + 2)
    
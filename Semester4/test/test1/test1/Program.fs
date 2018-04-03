﻿
let averageValue list =
    let rec calculateSum list sum n = 
        if list = [] then sum / double n
        else calculateSum (List.tail list) (sum + (sin <| List.head list)) (n + 1)
    calculateSum list (double 0) 0

type Node<'a> = 
    | Empty
    | Node of value: 'a * left: Node<'a> * right: Node<'a>
    
let findMinDistance tree =
    let rec find (root : Node<'a>) (minDepth : int) depth = 
        match root with
        | Empty -> 0
        | Node (_, b, c) ->
            match b,c with
            | Empty, Empty -> min minDepth depth
            | node, Empty -> find node minDepth (depth + 1)
            | Empty, node -> find node minDepth (depth + 1)
            | left, right -> 
                let newMin = find left minDepth (depth + 1)
                find right newMin (depth + 1)
    find tree 0 0
    
[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code
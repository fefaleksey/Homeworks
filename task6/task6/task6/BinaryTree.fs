namespace BST
open System.Collections
open System.Collections.Generic

module binaryTree =

    type Node<'a> =
        | Empty
        | Node of 'a * Node<'a> * Node<'a>
    let getValue this =
        match this with
        | Empty -> None
        | Node(value, _, _) -> Some(value)
    let treeTolist treeRoot = 
        let rec recToList rootNode ls =
            match rootNode with 
            | Empty -> ls
            | Node (cur, l, r) -> cur :: (List.append (recToList l ls) (recToList r ls))
        recToList treeRoot []
        
    /// <summary>
    /// Realize for IEnumerator
    /// </summary>
    type TreeEnumerator<'a>(root : Node<'a>) =
        let mutable position = -1
        let rewriteInList (root : Node<'a>) =
            let rec rewrite root list =
                match root with
                | Empty -> list
                | Node (el, left, right) -> el :: (List.append (rewrite left list) (rewrite right list))
            rewrite root []
        let mutable tree = rewriteInList root
        
        interface IEnumerator<'a> with
            member this.Reset() = 
                position <- -1        
            member this.MoveNext() =
                position <- position + 1
                tree.Length > position
            member this.Current = 
                tree.[position]
            member this.Dispose() = ()
            member this.get_Current() = 
                (this :> IEnumerator<'a>).Current :> obj
                
    /// <summary>
    /// Class which realise binary tree
    /// </summary>
    /// <typeparam name="T">T is type of value which we can put in tree</typeparam>            
    type BinaryTree<'a when 'a: comparison>() =
        let rec searchMin rootNode =
            match rootNode with
            | Empty -> Empty
            | Node (a, l, r) ->
                match l with
                | Empty -> rootNode
                | Node(_, _, _) -> searchMin l
        /// <summary>
        /// Root of the tree
        /// </summary>
        member val root = Empty with get, set
        /// <summary>
        /// Inserts an element with a value "value"
        /// </summary>
        /// <param name="value">value of element</param>
        member this.Add value =
            let rec add value root =
                match root with
                | Empty -> Node (value, Empty, Empty)
                | Node (a, l, r) ->
                    if value < a then Node (a, add value l, r)
                    elif value > a then Node (a, l, add value r)
                    else root
            this.root <- add value this.root 
        /// <summary>
        /// check included of element in tree
        /// </summary>
        /// <param name="value">value of element</param>
        /// <returns>true or falsefalse</returns>
        member this.isExist value =
            let rec search value root =
                match root with
                | Empty -> false
                | Node(a, l, r) ->
                    if value = a then true
                    elif value < a then search value l
                    else search value r
            search value this.root
        /// <summary>
        /// delete element from tree
        /// </summary>
        /// <param name="value">value of element</param>
        member this.Delete value =
            let rec delete value root =
                match root with
                | Empty -> Empty
                | Node(a, l, r) -> 
                    if value < a then Node(a, delete value l, r)
                    elif value > a then Node(a, l, delete value r)
                    else 
                        match l with
                        | Empty -> r
                        | _ -> 
                            let newValue = searchMin r |> getValue |> Option.get
                            let newRight = delete newValue r
                            Node(newValue, l, newRight)            
            if this.isExist value then this.root <- delete value this.root
        /// <summary>
        /// Reilize for IEnumerable
        /// </summary>
        member  this.GetEnumerator() = new TreeEnumerator<'a>(this.root)
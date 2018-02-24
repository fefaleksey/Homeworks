let multiplicationOfDigits x =
    let rec calculate s x = 
        if x > 10 then calculate (s * (x % 10)) (x / 10)
        else s * (x % 10)
    calculate 1 (abs x)

let searchNumber a list =
    let rec search a (listTail : List<int>) i = 
        match listTail with
        | head :: tail -> if a = listTail.Head then Some i else search a listTail.Tail (i + 1)
        | [] -> None
    search a list 0

let checkPalindrom (s : string) =
    let rec check (s : string) i j = 
        if j - i > 0 then
            if s.[i] = s.[j] then check s (i + 1) (j - 1) else false
        else true
    check s 0 (s.Length - 1)



let mergesort list =
    let rec merge list1 list2 =
        if list1 = [] then list2
        elif list2 = [] then list1
        elif list1.Head <= list2.Head then list1.Head :: merge list1.Tail list2
        else list2.Head :: merge list1 list2.Tail
    
    let rec sort (list : 'a list) =
        match list with
        | [] -> []
        | [a] -> [a]
        | [a; b] -> [min a b; max a b]
        | _ -> 
            let firstHalf = 
                list |> Seq.take (list.Length / 2) |> Seq.toList
            let secondHalf = 
                list |> Seq.skip (list.Length / 2) |> Seq.toList
            let sortedFirstHalf = sort firstHalf
            let sortedSecondHalf = sort secondHalf
            merge sortedFirstHalf sortedSecondHalf
    sort list
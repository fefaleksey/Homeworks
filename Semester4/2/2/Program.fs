let multiplicationOfDigits x =
    let rec calculate s x = 
        if x > 10 then calculate (s * (x % 10)) (x / 10)
        else s * (x % 10)
    calculate 1 x

let searchNumber a list =
    let rec search a (listTail : List<int>) i = 
        match listTail with
        | head :: tail -> if a = listTail.Head then i else search a listTail.Tail (i + 1)
        | [] -> -1
    search a list 0

let checkPalindrom (s : string) =
    let rec check (s : string) i j = 
        if j - i > 1 then
            if s.[i] = s.[j] then check s (i + 1) (j - 1) else false
        else true
    check s 0 (s.Length - 1)

let mergesort list =
    ()

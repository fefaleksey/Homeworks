let rec factorial n =
    if n > 1 then n * factorial (n-1) else 1

let rec fibonachi n =
    if n > 1 then fibonachi (n - 1) + fibonachi (n - 2) else 1

let reverse list = 
    let rec reverseRec lastList newList = 
        match lastList with
        | head :: tail -> reverseRec tail (head :: newList)
        | [] -> newList
    reverseRec list []

let createList n m =
    let rec pow n =
        if n > 0 then 2 * pow (n-1)
        else 1
    let rec create list n s =
        if s > n then create (pow s :: list) n (s - 1)
        else pow s :: list
    create [] n (n + m)
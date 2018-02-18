let rec factorial n =
    if n > 1 then n * factorial (n - 1) else 1

let rec fibonachi n =
    let a = 1 //F(n)
    let b = 0 //F(n-1)
    let rec calculate i x y = 
        if i < n then calculate (i + 1) (x + y) x
        else x
    calculate 1 a b

let reverse list = 
    let rec reverseRec lastList newList = 
        match lastList with
        | head :: tail -> reverseRec tail (head :: newList)
        | [] -> newList
    reverseRec list []

let createList n m =
    let rec pow n =
        if n > 0 then 2 * pow (n - 1)
        else 1
    let rec create list n s currentPow2=
        if s > n then create (currentPow2 / 2 :: list) n (s - 1) (currentPow2 / 2)
        else pow s :: list
    create [] n (n + m) (pow (n + m + 1))
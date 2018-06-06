
type LambdaTerm = 
    | Variable of char
    | Application of LambdaTerm * LambdaTerm
    | Abstraction of char * LambdaTerm

let getFvList t = 
    let rec recGetFV t acc = 
        match t with
        | Variable (x) -> x :: acc
        | Application (s, t) -> 
            let left = recGetFV s acc
            let right = recGetFV t acc
            List.append left right
        | Abstraction (x, s) -> 
            recGetFV s acc |> List.filter (fun y -> y <> x)
    recGetFV t []

let rec substitute s x t =
    match s with
    | Variable (y) -> if y = x then t else s
    | Application (s1, s2) -> Application (substitute s1 x t, substitute s2 x t)
    | Abstraction (y, s) -> 
        let fvs = getFvList s
        let fvt = getFvList t
        match t with
        | Variable (_) when y = x -> s
        | _ when 
            (not (List.contains y fvt)) ||
            (not (List.contains x fvs)) -> 
                Abstraction (y, substitute s x t)
        | _ -> 
            let alf = ['a'..'z']
            let fvst = List.append fvs fvt
            let z = alf |> List.filter (fun elem -> not (List.contains elem fvst)) |> List.head
            Abstraction (z, substitute (substitute s y (Variable (z))) x t)

let rec betaReduction t = 
    match t with
    | Variable (x) -> Variable (x)
    | Application (Abstraction (x, S), t) -> betaReduction (substitute S x t)
    | Application (s1, s2) -> Application (betaReduction s1, betaReduction s2)
    | Abstraction (x, t) -> Abstraction (x, betaReduction t)

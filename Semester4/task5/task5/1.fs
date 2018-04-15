namespace solve
    module task1 =
        let checkBrackets (s : string) =
            let list = s.ToCharArray() |> Array.toList
            let checkHead head (brackets : char list) =
                match head with
                | ')' -> brackets.Head = '('
                | ']' -> brackets.Head = '['
                | '}' -> brackets.Head = '{'
                | _ -> false
            let rec check list brackets =
                printfn "%A ||| %A" list brackets
                match list with
                | [] -> brackets = []
                | head :: tail -> 
                    match head with
                    |_ when (head = '{' || head = '[' || head = '(') -> check tail (head :: brackets)
                    | ')' | ']' | '}' -> if checkHead head brackets then check tail (List.tail brackets) else false
                    | _ -> check tail brackets
            check list []
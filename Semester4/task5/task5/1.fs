namespace task1
    module task1 =
        let check (s : string) =
            let list = s.ToCharArray() |> Array.toList
            
            let rec checkBrackets list brackets =
                match list with
                | [] -> brackets = []
                | head :: tail -> 
                    match head with
                    |_ when (head = '{' || head = '[' || head = '(') -> checkBrackets tail (head :: brackets)
                    |'}' -> if brackets.Head = '}' then checkBrackets list brackets.Tail else false
                    |']' -> if brackets.Head = ']' then checkBrackets list brackets.Tail else false
                    |')' -> if brackets.Head = ')' then checkBrackets list brackets.Tail else false
                    | _ -> checkBrackets list brackets.Tail
            
            checkBrackets list []
        ()
namespace Solve
    module task3 = 
        open System.Linq.Expressions
        open System
        open System.IO
        
        type Person (phone : string, name : string) = 
                    member this.phoneNumber = phone
                    member this.name = name
                    override this.ToString() = this.name + " | " + this.phoneNumber
        
        let printCommands = 
            printfn "Commands:"
            printfn "1 - exit"
            printfn "2 - add new record"
            printfn "3 - find phone number by name"
            printfn "4 - find name by phone number"
            printfn "5 - show all records"
            printfn "6 - save records to file"
            printfn "7 - load records from file"
        
        let addRecord person (phoneBook : List<Person>) = 
            person :: phoneBook
        
        let findPhone name (phoneBook  : List<Person>) = 
            let rec find (phoneBook : List<Person>) (name : string) = 
                match phoneBook with
                | [] -> None
                | h :: t -> if h.name = name then Some h.phoneNumber else find t name
            find phoneBook name
        
        let findName number  (phoneBook  : List<Person>) =
            let rec find (phoneBook : List<Person>) (number : string) = 
                match phoneBook with
                | [] -> None
                | h :: t -> if h.phoneNumber = number then Some h.name else find t number
            find phoneBook number
        
        let rec printAll (phoneBook : List<Person>) =
            match phoneBook with
            | [] -> ()
            | h :: t -> printfn "%O" h
                        printAll t
        
        let saveAll (fileName : string) (phoneBook  : List<Person>) = 
            let rec toString (lastList : List<Person>) newList = 
                match lastList with
                | h :: t -> toString t (h.ToString() :: newList)
                | [] -> newList
            let list = toString phoneBook []
            File.WriteAllLines(fileName, list)
            
        let load fileName (phoneBook  : List<Person>) = 
            let rec save (lines : List<string>) (phoneBook  : List<Person>) = 
                match lines with
                | [] -> phoneBook
                | head :: tail -> 
                    let personArr = head.Split ' '
                    let person = Person(personArr.[2], personArr.[0])
                    addRecord person phoneBook |> save tail
                    
            if not (System.IO.File.Exists fileName) then failwith "file not found"
            if System.IO.File.Exists fileName |> not 
            then 
                printfn "file not found"
                phoneBook
            else
                let lines = System.IO.File.ReadAllLines fileName |> Array.toList
                save lines phoneBook
            
        let run _ =
            printCommands
            let rec run (phoneBook : List<Person>) =
                printfn "Enter the command"
                let command = System.Console.ReadLine()
                match command with
                | "1" -> printfn "See you"
                | "2" -> printfn "Enter the name: "
                         let name = System.Console.ReadLine()
                         printfn "Enter phone number: "
                         let phoneNumber = System.Console.ReadLine()
                         let Person = Person(phoneNumber, name)
                         addRecord Person phoneBook |> run
                | "3" -> printfn "Enter the name: "
                         let name = System.Console.ReadLine()
                         findPhone name phoneBook |> printfn "%A"
                         run phoneBook
                | "4" -> printfn "Enter the phone number: "
                         let number = System.Console.ReadLine()
                         findName number phoneBook |> printfn "%A"
                         run phoneBook
                | "5" -> printAll phoneBook
                         run phoneBook
                | "6" -> printfn "Enter the name of file: "
                         let name = System.Console.ReadLine()
                         saveAll name phoneBook
                         printfn "Done"
                         run phoneBook
                | "7" -> printfn "Enter the name of file: "
                         let name = System.Console.ReadLine()
                         let loadedRecords = load name phoneBook
                         printfn "Done"
                         run loadedRecords
                | _ -> printfn "Unknown command"
                       run phoneBook
            run []
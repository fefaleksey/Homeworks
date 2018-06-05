open System
open System.Text.RegularExpressions
open System.Net
open System.IO

type Page = 
| Data of string
| Error

type Result = 
| Values of string[] * string[]
| Null

let downloadPage (url : string) =
    async { 
        try
            let req = WebRequest.Create(url)
            use! response = req.AsyncGetResponse()
            use stream = response.GetResponseStream()
            let reader = new StreamReader(stream)
            let html = reader.ReadToEnd()
            return Data(html)
        with
        | error -> return Error
    }
            
let downloadRefPages (url : string) =
    Async.RunSynchronously <|
        async {
            let! mainHtml = downloadPage url
            match mainHtml with
            | Error -> return Null
            | Data(s) ->
                let regex = new Regex(@"<a href=""http://.+?"">")
                let matches = regex.Matches(s)
                let references = [|for m in matches -> m.Value.Substring(9, m.Value.Length - 11)|]
                let tasks = [|for ref in references -> downloadPage ref|]
                let! results = Async.Parallel tasks
                let results' = Array.choose (function
                    | Error -> None
                    | Data(s) -> Some(s)) results
                return Values(references, results')
        }
        
let printResults result =
    match result with
    | Null -> ()
    | Values(references, results) ->
                for i in 0..references.Length - 1 do
                    printfn "%s --- %d" references.[i] results.[i].Length
    

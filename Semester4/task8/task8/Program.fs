open System
open System.Text.RegularExpressions
open System.Net
open System.IO

type Result = 
| Data of string
| Error

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
            | Error -> ()
            | Data(s) ->
                let regex = new Regex(@"<a href=""http://.+?"">")
                let matches = regex.Matches(s)
                let references = [|for m in matches -> m.Value.Substring(9, m.Value.Length - 11)|]
                let tasks = [|for ref in references -> downloadPage ref|]
                let! results = Async.Parallel tasks
                let results' = Array.choose (function
                    | Error -> None
                    | Data(s) -> Some(s)) results
                for i in 0..references.Length - 1 do
                    printfn "%s --- %d" references.[i] results'.[i].Length 
        }
        
[<EntryPoint>]
let main argv =
    downloadRefPages "http://hwproj.me/courses/9/terms/4"
    0 // return an integer exit code

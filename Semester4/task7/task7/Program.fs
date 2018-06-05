type RoundingBuilder(digit : int) =
    member this.Bind(x : float, f : float -> float) =
        System.Math.Round(f x, digit)
    member this.Return(x) = x

open System

let strToInt str  = 
    match Int32.TryParse(str) with
    | false, _ -> None
    | true, value  -> Some value

type MaybeBuilder() =
    member this.Bind(m, f) = Option.bind f (strToInt m)
    member this.Return(x) = Some(x)

open System

[<EntryPoint>]
let main argv =
    0
    
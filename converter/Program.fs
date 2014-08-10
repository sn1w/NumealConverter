// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
open Converter.Logic

[<EntryPoint>]
let main argv =
    let input = ["一"; "二万"; "万"; "千"; "満"] in
    let converter = new Converter() in
    input 
    |> Seq.iter (fun arg -> converter.Convert arg |> printfn "%s")
    0 // return an integer exit code

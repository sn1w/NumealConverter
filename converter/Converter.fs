namespace Converter.Logic 
open System

(* Record of display KanSuuji *)
type ValueInfo = 
    { value : int
      digit : int
      overwrite : bool }

module ConvertUtils = 
    let makeValueWithF (value : int, digit : int, canOverwrite : bool) =
        {value = value; digit = digit; overwrite=canOverwrite}

    let makeValue (value : int, digit : int) = 
        makeValueWithF(value, digit, false)

    
    let ToString(x : ValueInfo) : string = 
        let charArray = 
            [ for i in 1..x.digit -> "0" ]
        x.value.ToString() :: charArray
        |> Seq.fold (fun l r -> l + r) ""
    
    let private ParseChar(c : char) : ValueInfo option = 
        match c with
        | '１' | '一' | '壱' -> makeValue (1, 0) |> Some
        | '２' | '二' | '弐' -> makeValue (2, 0) |> Some
        | '３' | '三' | '参' -> makeValue (3, 0) |> Some
        | '４' | '四' -> makeValue (4, 0) |> Some
        | '５' | '五' | '伍' -> makeValue (5, 0) |> Some
        | '６' | '六' -> makeValue (6, 0) |> Some
        | '７' | '七' -> makeValue (7, 0) |> Some
        | '８' | '八' -> makeValue (8, 0) |> Some
        | '９' | '九' -> makeValue (9, 0) |> Some
        | '０' | '〇' | '零' -> makeValue (0, 0) |> Some
        | '十' | '拾' -> makeValueWithF (0, 1, true) |> Some
        | '百' -> makeValueWithF (0, 2, true) |> Some
        | '千' -> makeValueWithF (0, 3, true) |> Some
        | '万' | '萬' -> makeValueWithF (0, 4, true) |> Some
        | '億' -> makeValueWithF (0, 8, true) |> Some
        | '兆' -> makeValueWithF (0, 12, true) |> Some
        | _ -> None
    
    /// <summary>
    /// Parse Kansuuji.
    /// If Failed, then return Seq.empty
    /// </summary>
    let ParseValue(s : string) : seq<ValueInfo> = 
        let temporary = s.ToCharArray() |> Seq.map (fun x -> ParseChar x)
        if (Seq.exists (fun (x : ValueInfo option) -> x.IsNone) temporary) then Seq.empty
        else Seq.map (fun (x : ValueInfo option) -> x.Value) temporary
    

type Number (data : list<ValueInfo>) =

    let rec getDigit (digit:int, src : List<ValueInfo>) : ValueInfo option = 
        match src with
        | h::t -> 
            if digit = h.digit then 
                Some(h) 
            else 
                getDigit(digit, t)
         | [] -> None  
           
    member this.Set(x : ValueInfo) : Number option =
        let setImpl (y:ValueInfo, ls) = 
            let filtered = List.filter (fun itm -> not(itm.digit = y.digit)) ls in
            y::ls   
        if data.IsEmpty then
            Some(new Number(setImpl(x,data)))
        else
            // get max digit
            let maxDigit = List.sortBy (fun itm -> itm.digit) data |> List.rev |> List.head
            if x.digit > maxDigit.digit then
                (* add *)
                Some(new Number(setImpl(x, data)))
            else
                let isErrorCase = maxDigit.digit > 3 && x.digit > 3
                let needsBasePoint = x.digit < 4 && maxDigit.digit > 3 && not(x.value = 0)
                let newDigit = 
                    if x.digit = 0 && maxDigit.overwrite = false then 
                        maxDigit.digit + 1 
                    else if isErrorCase then
                        maxDigit.digit + x.digit + 1
                    else if needsBasePoint then
                        (maxDigit.digit / 4) * 4
                    else
                        maxDigit.digit + x.digit in
                let newInfo = ConvertUtils.makeValueWithF(x.value, newDigit, x.overwrite)
                // calc based on maxDigit
                if maxDigit.overwrite && not(isErrorCase) then
                    let filtered = List.filter (fun itm2 -> not(itm2.digit = maxDigit.digit)) data in
                    Some(new Number(setImpl(newInfo, filtered)))
                else
                    Some(new Number(setImpl(newInfo, data)))             
        
    override this.ToString() =
        let rec genString (x:int, ls:List<ValueInfo>, src:string):string = 
            if x < 0 then 
                src
            else
                let rs = List.tryFind (fun n -> n.digit = x) ls in
                match rs with
                | Some(n) -> 
                    if n.value = 0 && n.overwrite then
                        genString(x-1, ls, src + "1")
                    else
                        genString(x-1, ls, src + n.value.ToString())
                | None -> genString(x-1, ls, src + "0")

        let maxDigit = List.sortBy (fun x -> x.digit) data |> List.rev |> List.head in
        genString(maxDigit.digit, data, "")

type Converter() = 
    member this.Convert(s : string) : string =
        let Calculate (s : seq<ValueInfo>) : string = 
            let number = new Number([]) in
            try 
                let calcNumber = 
                    Seq.toList s 
                    |> List.rev
                    |> List.fold (fun (num:Number) info -> (num.Set info).Value) number
                 
                calcNumber.ToString()
            with e ->
                String.Empty
        let ParseImpl(s : string) : string =
            let infos = ConvertUtils.ParseValue s in
            if Seq.isEmpty infos then String.Empty 
            else Calculate infos
        ParseImpl s
    member this.ConvertWidth(s: string) : string =
        let toWidth c =
            match c with
            | '1' -> '１'
            | '2' -> '２'
            | '3' -> '３'
            | '4' -> '４'
            | '5' -> '５'
            | '6' -> '６'
            | '7' -> '７'
            | '8' -> '８'
            | '9' -> '９'
            | '0' -> '０'
            | _ -> c
        let small = this.Convert s in
        small.ToCharArray()
        |> Seq.map (fun x -> toWidth x)
        |> Seq.fold (fun x y -> x + y.ToString()) ""


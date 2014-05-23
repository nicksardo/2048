﻿module TwentyFortyEight

type Direction = 
    | Up
    | Down
    | Left
    | Right

let flatten (A:'a[,]) = A |> Seq.cast<'a>

let merge (direction:Direction) (line:int[]) =
    let innerMerge (array:int[]) = 
        let skip = ref false
        Array.init array.Length (fun i ->
            let x = array.[i]
            if !skip then
                skip := false
                Option.None
            else if i <> array.Length - 1 && x = array.[i+1] then
                skip := true
                Option.Some((x * 2, x * 2))
            else
                Option.Some((x, 0))
        )
                
    match direction with 
        | Up | Left ->  
            line
            |> innerMerge
            |> Array.filter Option.isSome
            |> Array.map Option.get

        | Down | Right -> 
            line 
            |> Array.rev
            |> innerMerge
            |> Array.rev
            |> Array.filter Option.isSome
            |> Array.map Option.get


let shift (direction:Direction) (board:Option<int>[,]) = 
    let l = Array2D.length1 board

    let getLine = 
        match direction with 
        | Up | Down -> fun (x:int) -> board.[*, x] 
        | Left | Right -> fun (x:int) -> board.[x, *] 

    let getPadding (length:int) = 
        match direction with 
        | Up | Left -> (0, l - length)
        | Down | Right -> (l - length, 0)

    let lineResults = Array.init l (fun x -> 
        let lineResults = 
            getLine x
            |> Array.filter Option.isSome 
            |> Array.map Option.get
            |> merge direction

        let line = Array.map (fun (l, _) -> l) lineResults
        let newPoints = Array.sumBy (fun (_, points) -> points) lineResults

        let (left, right) = getPadding line.Length
        let newLine = Array.init l (fun x ->
            if x < left || x >= left + line.Length || line.Length = 0 then
                Option.None
            else
                let v = line.[x-left]
                Option.Some(v)
        )
        (newLine, newPoints)
    )
    let lines = Array.map (fun (l, _) -> l) lineResults
    let newPoints = Array.sumBy (fun (_, points) -> points) lineResults

    let getValue (row:int) (col:int) = 
        match direction with 
        | Up | Down -> lines.[col].[row]
        | Left | Right -> lines.[row].[col]

    let newBoard = Array2D.init l l getValue

    (newBoard, newPoints)

let newTile (r:System.Random) = 
        let v = 
            if r.NextDouble() < 0.9 then
                2
            else 
                4
        Option.Some(v)

let move (direction:Direction) (board:Option<int>[,]) (r:System.Random) =
    let (shiftedBoard, newPoints) = shift direction board

    let empties =
        shiftedBoard
        |> Array2D.mapi (fun row col v ->
                (row, col, v)
            )
        |> flatten
        |> Seq.filter (fun (_, _, v) -> Option.isNone v)
        |> Seq.map (fun (r, c, _) -> (r, c))

    let chosenTile = r.Next(Seq.length empties)
    let (row, col) = Seq.nth chosenTile empties

    Array2D.set shiftedBoard row col (newTile r)

    (shiftedBoard, newPoints)
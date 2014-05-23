module TwentyFortyEight

type Direction = 
    | Up
    | Down
    | Left
    | Right

let merge (line:int[]) =
    seq {
        for i in 0 .. line.Length - 1 do
            let x = line.[i]
            if i <> line.Length - 1 && x = line.[i+1] then
                yield (x * 2, x * 2)
            else
                yield (x, 0)
    }


let command (direction:Direction) (board:Option<int>[,]) = 
    let l = int(System.Math.Sqrt(float(board.Length)))

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
            |> merge
            |> Seq.toArray

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

module TwentyFortyEight

type Direction = 
    | Up
    | Down
    | Left
    | Right

let flatten (A:'a[,]) = A |> Seq.cast<'a>
type Board = Option<int>[,]

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


let shift (direction:Direction) (board:Board) = 
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

let newTileValue (r:System.Random) = 
        let v = 
            if r.NextDouble() < 0.9 then
                2
            else 
                4
        Option.Some(v)

let move (direction:Direction) (board:Board) (r:System.Random) =
    let (shiftedBoard, newPoints) = shift direction board
    let hasChanged = board <> shiftedBoard

    if hasChanged then
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

        Array2D.set shiftedBoard row col (newTileValue r)

    (hasChanged, shiftedBoard, newPoints)


let shuffle (r:System.Random) (array:'a[]) = 
    let n = array.Length
    for x in 1..n do
        let i = n-x
        let j = r.Next(i+1)
        let tmp = array.[i]
        array.[i] <- array.[j]
        array.[j] <- tmp
    array

let newBoard (size:int) (r:System.Random) =
    if size <= 1 then
        raise (System.ArgumentException("Size must be greater than 1"))

    let board = Array2D.create size size Option.None
    let locs = 
        board 
            |> Array2D.mapi (fun row col v ->
                    (row, col)
                )
            |> flatten
            |> Seq.toArray
            |> shuffle r

    let (aRow, aCol) = Array.get locs 0
    let (bRow, bCol) = Array.get locs 1

    Array2D.set board aRow aCol (newTileValue r)
    Array2D.set board bRow bCol (newTileValue r)
    board

let hasReached (level:int) (board:Board) = 
    board
        |> flatten
        |> Seq.exists (fun tile -> Option.isSome tile && tile.Value >= level)
module TwentyFortyEightTests.Helpers

let n = 
    Option.None

let s (i:int) =
    Option.Some(i)

let toBoard (board:Option<int>[][]) =
    let l = Array.length board
    Array2D.init l l (fun row col -> board.[row].[col])



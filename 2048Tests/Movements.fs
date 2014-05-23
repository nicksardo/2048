module TwentyFortyEightTests

open TwentyFortyEight
open NUnit.Framework
open FsUnit


[<TestFixture>]
type MovementTests() =
    let n = 
        Option.None

    let s (i:int) =
        Option.Some(i)

    let to2d (board:Option<int>[][]) =
        let l = Array.length board
        Array2D.init l l (fun row col -> board.[row].[col])

    let testMovement board direction expected expectedPoints =
        let (newBoard, points) = command direction (to2d board)
        newBoard |> should equal (to2d expected)
        points |> should equal expectedPoints

    [<Test>]
    member test.``Move Up``() =
        let d = Direction.Up
        let board = [| 
                        [| n; s 2; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        let expected=[| 
                        [| n; s 2; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        testMovement board d expected 0

        let board = [| 
                        [| n; n; n; n; |]; 
                        [| n; s 2; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        let expected=[| 
                        [| n; s 2; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        testMovement board d expected 0

        let board = [| 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; s 2; n; n; |]; 
                        |]
        let expected=[| 
                        [| n; s 2; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        testMovement board d expected 0

        let board = [| 
                        [| n; s 16; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; s 16; n; n; |]; 
                        |]
        let expected=[| 
                        [| n; s 32; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        testMovement board d expected 32

    [<Test>]
    member test.``Move Left``() =
        let d = Direction.Left
        let board = [| 
                        [| n; n; n; n; |]; 
                        [| s 4; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        let expected=[| 
                        [| n; n; n; n; |]; 
                        [| s 4; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        testMovement board d expected 0

        let board = [| 
                        [| n; n; n; n; |]; 
                        [| n; s 4; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        let expected=[| 
                        [| n; n; n; n; |]; 
                        [| s 4; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        testMovement board d expected 0

        let board=[| 
                        [| n; n; n; n; |]; 
                        [| n; n; n; s 4; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        let expected=[| 
                        [| n; n; n; n; |]; 
                        [| s 4; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        testMovement board d expected 0

        let board=[| 
                        [| n; n; n; n; |]; 
                        [| n; s 4; n; s 4; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        let expected=[| 
                        [| n; n; n; n; |]; 
                        [| s 8; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        testMovement board d expected 8
        
    [<Test>]
    member test.``Move Right``() =
        let d = Direction.Right
        let board = [| 
                        [| n; n; n; n; |]; 
                        [| s 512; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        let expected=[| 
                        [| n; n; n; n; |]; 
                        [| n; n; n; s 512; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        testMovement board d expected 0

        let board = [| 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; s 256; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        let expected=[| 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; s 256; |]; 
                        [| n; n; n; n; |]; 
                        |]
        testMovement board d expected 0

        let board=[| 
                        [| n; n; n; n; |]; 
                        [| n; n; n; s 4; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        let expected=[| 
                        [| n; n; n; n; |]; 
                        [| n; n; n; s 4; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        testMovement board d expected 0

        let board=[| 
                        [| n; n; n; n; |]; 
                        [| n; s 512; n; s 512; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        let expected=[| 
                        [| n; n; n; n; |]; 
                        [| n; n; n; s 1024; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        testMovement board d expected 1024
       
    [<Test>]
    member test.``Move Down``() =
        let d = Direction.Down
        let board = [| 
                        [| n; s 1024; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        let expected=[| 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; s 1024; n; n; |]; 
                        |]
        testMovement board d expected 0

        let board = [| 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; s 256; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        let expected=[| 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; s 256; n; n; |]; 
                        |]
        testMovement board d expected 0

        let board=[| 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; s 4; |]; 
                        |]
        let expected=[| 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; s 4; |]; 
                        |]
        testMovement board d expected 0

        let board=[| 
                        [| n; n; n; n; |]; 
                        [| n; s 512; n; s 512; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        let expected=[| 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; s 512; n; s 512; |]; 
                        |]
        testMovement board d expected 0

        let board=[| 
                        [| n; s 512; n; n; |]; 
                        [| n; s 512; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        let expected=[| 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; s 1024; n; n; |]; 
                        |]
        testMovement board d expected 1024
       

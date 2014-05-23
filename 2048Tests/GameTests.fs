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

    let testMovement board expected =
        let (newBoard, points) = command Direction.Up (to2d board)
        newBoard |> should equal (to2d expected)
        points |> should equal 0

    [<Test>]
    member test.``Move Up``() =
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
        testMovement board expected

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
        testMovement board expected

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
        testMovement board expected

    [<Test>]
    member test.``Move Left``() =
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
        testMovement board expected

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
        testMovement board expected

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
        testMovement board expected
       
       

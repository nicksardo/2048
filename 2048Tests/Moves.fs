module TwentyFortyEightTests.Moves

open TwentyFortyEight
open Helpers
open NUnit.Framework
open FsUnit

[<TestFixture>]
type MovementTests() =

    let testMove board direction expected expectedPoints r =
        let (newBoard, points) = move direction board r
        newBoard |> should equal expected
        points |> should equal expectedPoints

    [<Test>]
    member test.``Move & Get New Tile``() =
        let r = new System.Random(2048)
        let board = [| 
                        [| n; s 2; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
                       |> to2D

        let expected = Array2D.copy board
        Array2D.set expected 2 2 (s 2)
        testMove board Direction.Up expected 0 r
         
        let board =[| 
                        [| n; n; n; n; |]; 
                        [| n; n; n; s 8; |]; 
                        [| n; s 32; s 64; s 128; |]; 
                        [| s 8; s 2; s 8; s 4; |]; 
                    |]
                       |> to2D

        let expected = Array2D.copy board
        Array2D.set expected 0 2 (s 2)
        testMove board Direction.Down expected 0 r

        let board =[| 
                        [| n; n; n; n; |]; 
                        [| n; n; n; s 8; |]; 
                        [| n; s 32; s 64; s 128; |]; 
                        [| s 8; s 2; s 8; s 4; |]; 
                    |]
                       |> to2D

        let expected = Array2D.copy board
        Array2D.set expected 1 2 (s 2)
        testMove board Direction.Down expected 0 r

        let board =[| 
                        [| n; n; n; n; |]; 
                        [| n; n; n; s 8; |]; 
                        [| n; s 32; s 64; s 128; |]; 
                        [| s 8; s 2; s 8; s 4; |]; 
                    |]
                       |> to2D

        let expected = Array2D.copy board
        Array2D.set expected 1 0 (s 2)
        testMove board Direction.Down expected 0 r
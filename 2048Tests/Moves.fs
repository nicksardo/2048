module TwentyFortyEightTests.Moves

open TwentyFortyEight
open Helpers
open NUnit.Framework
open FsUnit

[<TestFixture>]
type MovementTests() =

    let r = System.Random(2048)
    let testMove board direction expected expectedPoints =
        let (newBoard, points) = move direction (to2d board) r
        newBoard |> should equal (to2d expected)
        points |> should equal expectedPoints

    [<Test>]
    member test.``Move & Get New Tile``() =
        let board = [| 
                        [| n; s 2; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        let expected=[| 
                        [| n; s 2; n; n; |]; 
                        [| n; n; n; n; |]; 
                        [| n; n; s 2; n; |]; 
                        [| n; n; n; n; |]; 
                        |]
        testMove board Direction.Up expected 0
module TwentyFortyEightTests.Games

open TwentyFortyEight
open Helpers
open NUnit.Framework
open FsUnit

[<TestFixture>]
type GameTests() =
    [<Test>]
    member test.``HasWon``() =
        let board = [| 
                        [| n; n; n; n; |]; 
                        [| n; s 512; n; n; |]; 
                        [| n; n; s 2048; n; |]; 
                        [| n; n; n; n; |]; 
                        |]

        board
            |> toBoard
            |> hasReached 2048
            |> should equal true

        let board = [| 
                        [| n; n; n; n; |]; 
                        [| n; s 512; n; n; |]; 
                        [| n; n; s 1024; n; |]; 
                        [| n; n; n; n; |]; 
                        |]

        board
            |> toBoard
            |> hasReached 2048
            |> should equal false
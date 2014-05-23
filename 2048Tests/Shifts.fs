module TwentyFortyEightTests.Shifts

open TwentyFortyEight
open Helpers
open NUnit.Framework
open FsUnit

[<TestFixture>]
type ShiftTests() =
    let testShift board direction expected expectedPoints =
        let (newBoard, points) = shift direction (to2d board)
        newBoard |> should equal (to2d expected)
        points |> should equal expectedPoints

    [<Test>]
    member test.``Shift Up``() =
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
        testShift board d expected 0

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
        testShift board d expected 0

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
        testShift board d expected 0

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
        testShift board d expected 32

    [<Test>]
    member test.``Shift Left``() =
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
        testShift board d expected 0

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
        testShift board d expected 0

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
        testShift board d expected 0

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
        testShift board d expected 8
        
    [<Test>]
    member test.``Shift Right``() =
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
        testShift board d expected 0

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
        testShift board d expected 0

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
        testShift board d expected 0

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
        testShift board d expected 1024
       
    [<Test>]
    member test.``Shift Down``() =
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
        testShift board d expected 0

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
        testShift board d expected 0

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
        testShift board d expected 0

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
        testShift board d expected 0

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
        testShift board d expected 1024
       

    [<Test>]
    member test.``Complex Boards``() =
        let board = [| 
                        [| s 4; s 16; s 4; s 128; |]; 
                        [| s 4; s 16; s 64; s 2; |]; 
                        [| s 4; s 8; s 2; n; |]; 
                        [| s 2; n; n; n; |]; 
                        |]
        let expected=[| 
                        [| n; n; n; n; |]; 
                        [| s 4; n; s 4; n; |]; 
                        [| s 8; s 32; s 64; s 128; |]; 
                        [| s 2; s 8; s 2; s 2; |]; 
                        |]
        testShift board Direction.Down expected 40

        let board = expected
        let expected=[| 
                        [| n; n; n; n; |]; 
                        [| n; n; n; s 8; |]; 
                        [| s 8; s 32; s 64; s 128; |]; 
                        [| n; s 2; s 8; s 4; |]; 
                        |]
        testShift board Direction.Right expected 12

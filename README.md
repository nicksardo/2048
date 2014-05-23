F# 2048
====

Fsharp implementation of 2048 for bot testing  
API  
```Fsharp
newBoard (size:int) (r:System.Random)  = Board
move (direction:Direction) (board:Board) (r:System.Random)  = (hasChanged, newBoard, newPoints)
hasReached (level:int) (board:Board)  = bool
hasNoMoves(board:Board)  = bool
```


Example:  
```Fsharp
let r = new System.Random(2048)

let board = newBoard 4 r;;

val board : int option [,] = [[null; null; null; null]
                              [null; null; null; null]
                              [null; Some 2; null; null]
                              [null; Some 2; null; null]]

> let (moved, b, newPoints) = move Direction.Up board r;;

val newPoints : int = 4
val b : int option [,] = [[null; Some 4; Some 2; null]
                                 [null; null; null; null]
                                 [null; null; null; null]
                                 [null; null; null; null]]
val moved : bool = true

> let (moved, b, newPoints) = move Direction.Up b r;;

val newPoints : int = 0
val b : int option [,] = [[null; Some 4; Some 2; null]
                                 [null; null; null; null]
                                 [null; null; null; null]
                                 [null; null; null; null]]
val moved : bool = false

> let (moved, b, newPoints) = move Direction.Right b r;;

val newPoints : int = 0
val b : int option [,] = [[null; null; Some 4; Some 2]
                                 [null; null; null; null]
                                 [null; null; null; null]
                                 [null; null; null; Some 2]]
val moved : bool = true

> let (moved, b, newPoints) = move Direction.Up b r;;

val newPoints : int = 4
val b : int option [,] = [[null; Some 2; Some 4; Some 4]
                                 [null; null; null; null]
                                 [null; null; null; null]
                                 [null; null; null; null]]
val moved : bool = true

> let (moved, b, newPoints) = move Direction.Right b r;;

val newPoints : int = 8
val b : int option [,] = [[null; null; Some 2; Some 8]
                                 [null; null; null; Some 2]
                                 [null; null; null; null]
                                 [null; null; null; null]]
val moved : bool = true

> let (moved, b, newPoints) = move Direction.Left b r;;

val newPoints : int = 0
val b : int option [,] = [[Some 2; Some 8; null; null]
                                 [Some 2; null; null; null]
                                 [null; null; null; null]
                                 [Some 2; null; null; null]]
val moved : bool = true

> let (moved, b, newPoints) = move Direction.Right b r;;

val newPoints : int = 0
val b : int option [,] = [[null; null; Some 2; Some 8]
                                 [Some 2; null; null; Some 2]
                                 [null; null; null; null]
                                 [null; null; null; Some 2]]
val moved : bool = true

> let (moved, b, newPoints) = move Direction.Up b r;;

val newPoints : int = 4
val b : int option [,] = [[Some 2; null; Some 2; Some 8]
                                 [null; null; Some 4; Some 4]
                                 [null; null; null; null]
                                 [null; null; null; null]]
val moved : bool = true

> let (moved, b, newPoints) = move Direction.Right b r;;

val newPoints : int = 12
val b : int option [,] = [[null; null; Some 4; Some 8]
                                 [null; null; null; Some 8]
                                 [null; null; null; null]
                                 [null; null; Some 2; null]]
val moved : bool = true

> let (moved, b, newPoints) = move Direction.Up b r;;

val newPoints : int = 16
val b : int option [,] = [[null; null; Some 4; Some 16]
                                 [null; null; Some 2; null]
                                 [null; null; null; null]
                                 [Some 2; null; null; null]]
val moved : bool = true
```

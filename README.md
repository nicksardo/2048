F# 2048
====

Fsharp implementation of 2048 for bot testing

```Fsharp
let r = new System.Random(2048)

let board = newBoard 4 r;;

val board : int option [,] = [[null; null; null; null]
                              [null; null; null; null]
                              [null; Some 2; null; null]
                              [null; Some 2; null; null]]

> let (moved, newBoard, newPoints) = move Direction.Up board r;;

val newPoints : int = 4
val newBoard : int option [,] = [[null; Some 4; Some 2; null]
                                 [null; null; null; null]
                                 [null; null; null; null]
                                 [null; null; null; null]]
val moved : bool = true

> let (moved, newBoard, newPoints) = move Direction.Up newBoard r;;

val newPoints : int = 0
val newBoard : int option [,] = [[null; Some 4; Some 2; null]
                                 [null; null; null; null]
                                 [null; null; null; null]
                                 [null; null; null; null]]
val moved : bool = false

> let (moved, newBoard, newPoints) = move Direction.Right newBoard r;;

val newPoints : int = 0
val newBoard : int option [,] = [[null; null; Some 4; Some 2]
                                 [null; null; null; null]
                                 [null; null; null; null]
                                 [null; null; null; Some 2]]
val moved : bool = true

> let (moved, newBoard, newPoints) = move Direction.Up newBoard r;;

val newPoints : int = 4
val newBoard : int option [,] = [[null; Some 2; Some 4; Some 4]
                                 [null; null; null; null]
                                 [null; null; null; null]
                                 [null; null; null; null]]
val moved : bool = true

> let (moved, newBoard, newPoints) = move Direction.Right newBoard r;;

val newPoints : int = 8
val newBoard : int option [,] = [[null; null; Some 2; Some 8]
                                 [null; null; null; Some 2]
                                 [null; null; null; null]
                                 [null; null; null; null]]
val moved : bool = true

> let (moved, newBoard, newPoints) = move Direction.Left newBoard r;;

val newPoints : int = 0
val newBoard : int option [,] = [[Some 2; Some 8; null; null]
                                 [Some 2; null; null; null]
                                 [null; null; null; null]
                                 [Some 2; null; null; null]]
val moved : bool = true

> let (moved, newBoard, newPoints) = move Direction.Right newBoard r;;

val newPoints : int = 0
val newBoard : int option [,] = [[null; null; Some 2; Some 8]
                                 [Some 2; null; null; Some 2]
                                 [null; null; null; null]
                                 [null; null; null; Some 2]]
val moved : bool = true

> let (moved, newBoard, newPoints) = move Direction.Up newBoard r;;

val newPoints : int = 4
val newBoard : int option [,] = [[Some 2; null; Some 2; Some 8]
                                 [null; null; Some 4; Some 4]
                                 [null; null; null; null]
                                 [null; null; null; null]]
val moved : bool = true

> let (moved, newBoard, newPoints) = move Direction.Right newBoard r;;

val newPoints : int = 12
val newBoard : int option [,] = [[null; null; Some 4; Some 8]
                                 [null; null; null; Some 8]
                                 [null; null; null; null]
                                 [null; null; Some 2; null]]
val moved : bool = true

> let (moved, newBoard, newPoints) = move Direction.Up newBoard r;;

val newPoints : int = 16
val newBoard : int option [,] = [[null; null; Some 4; Some 16]
                                 [null; null; Some 2; null]
                                 [null; null; null; null]
                                 [Some 2; null; null; null]]
val moved : bool = true
```

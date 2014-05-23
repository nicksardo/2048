F# 2048
====

Fsharp implementation of 2048 for bot testing

```Fsharp

 let board = newBoard 4 r;;

val board : int option [,] = [[null; null; null; null]
                              [null; null; Some 2; null]
                              [Some 2; null; null; null]
                              [null; null; null; null]]

> let (moved, newBoard, _) = move Direction.Up board r;;

val newBoard : int option [,] = [[Some 2; null; Some 2; null]
                                 [null; null; null; null]
                                 [null; null; null; Some 2]
                                 [null; null; null; null]]
val moved : bool = true

> let (moved, newBoard, _) = move Direction.Up newBoard r;;

val newBoard : int option [,] = [[Some 2; null; Some 2; Some 2]
                                 [null; null; null; null]
                                 [null; null; null; null]
                                 [null; Some 2; null; null]]
val moved : bool = true

> let (moved, newBoard, _) = move Direction.Up newBoard r;;

val newBoard : int option [,] = [[Some 2; Some 2; Some 2; Some 2]
                                 [null; null; null; null]
                                 [null; null; null; null]
                                 [null; Some 2; null; null]]
val moved : bool = true

> let (moved, newBoard, _) = move Direction.Right newBoard r;;

val newBoard : int option [,] = [[null; Some 2; Some 4; Some 4]
                                 [null; null; null; null]
                                 [null; null; null; null]
                                 [null; null; null; Some 2]]
val moved : bool = true

> let (moved, newBoard, _) = move Direction.Right newBoard r;;

val newBoard : int option [,] = [[null; null; Some 2; Some 8]
                                 [null; null; Some 2; null]
                                 [null; null; null; null]
                                 [null; null; null; Some 2]]
val moved : bool = true

> let (moved, newBoard, _) = move Direction.Up newBoard r;;

val newBoard : int option [,] = [[null; null; Some 4; Some 8]
                                 [null; null; Some 4; Some 2]
                                 [null; null; null; null]
                                 [null; null; null; null]]
val moved : bool = true

> let (moved, newBoard, _) = move Direction.Right newBoard r;;

val newBoard : int option [,] = [[null; null; Some 4; Some 8]
                                 [null; null; Some 4; Some 2]
                                 [null; null; null; null]
                                 [null; null; null; null]]
val moved : bool = false
```

open System


type GeometricFigure =
    | Rectangle of width: float * height: float
    | Square of side: float
    | Circle of radius: float


let calculateArea figure =
    match figure with
    | Rectangle(width, height) -> width * height
    | Square(side) -> side * side
    | Circle(radius) -> Math.PI * radius ** 2.0


let printFigure figure =
    match figure with
    | Rectangle(w, h) ->
        Console.WriteLine($"Прямоугольник: {w} x {h}: площадь {(calculateArea figure)}")
    | Square(s) ->
        Console.WriteLine($"Квадрат: {s}: площадь {(calculateArea figure)}")
    | Circle(r) ->
        Console.WriteLine($"Круг: {r}: площадь {(calculateArea figure)}")


let figures = [
    Rectangle(3.0, 4.0)
    Square(5.0)
    Circle(2.0)
]

figures |> List.iter printFigure
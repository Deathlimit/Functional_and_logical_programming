open System


type IPrint =
    abstract Print : unit -> unit


[<AbstractClass>]
type GeometricFigure() =
    abstract Area : float


type Rectangle(width: float, height: float) =
    inherit GeometricFigure()
    member this.Width = width
    member this.Height = height
    override this.Area = this.Width * this.Height
    override this.ToString() = 
        sprintf $"Прямоугольник: ширина {this.Width}, высота {this.Height}, площадь {this.Area}"
    interface IPrint with
        member this.Print() = Console.WriteLine(this.ToString())


type Square(side: float) =
    inherit Rectangle(side, side)
    override this.ToString() = 
        sprintf $"Квадрат: сторона {this.Width}, площадь {this.Area}"


type Circle(radius: float) =
    inherit GeometricFigure()
    member this.Radius = radius
    override this.Area = Math.PI * this.Radius ** 2.0
    override this.ToString() = 
        sprintf $"Круг: радиус {this.Radius}, площадь {this.Area}"
    interface IPrint with
        member this.Print() = Console.WriteLine(this.ToString())


let printFigure (figure: IPrint) = figure.Print()

let rect = Rectangle(8.0, 9.0)
let square = Square(5.0)
let circle = Circle(3.0)

printFigure rect
printFigure square
printFigure circle

Console.WriteLine($"ToString: {rect}") 
Console.WriteLine($"ToString: {square}") 
Console.WriteLine($"ToString: {circle}") 
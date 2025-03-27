open System

//printfn "Hello from F#"

type SolveResult =
    None
    | Linear of float
    | Quadratic of float*float

let solve a b c = 
    let D = b*b-4. * a * c
    if a =0. then
        if b=0. then None
        else Linear(-c/b)
    else
        if D<0 then None
        else Quadratic(((-b+sqrt(D))/(2.* a), (-b-sqrt(D))/(2.*a)))


let areaCircle radius = 
    Math.PI * radius * radius

let multiplyAreaHeight area height =
    area * height

let volumeCylinderSuperPos =
    areaCircle >> multiplyAreaHeight

let volumeCylinderCurr radius height =
    (areaCircle radius) * height



[<EntryPoint>]
let main argv = 
    Console.Write("Радиус = ")
    let radius = Console.ReadLine() |> float
    Console.Write("Высота = ")
    let height = Console.ReadLine() |> float
    Console.WriteLine($"Площадь круга: {areaCircle radius}")
    Console.WriteLine($"Объем цилиндра: {volumeCylinderSuperPos radius height}")
    Console.WriteLine()
    Console.WriteLine($"Площадь круга: {areaCircle radius}")
    Console.WriteLine($"Объем цилиндра: {volumeCylinderCurr radius height}")



    0



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

let rec sumDigitsUp num =
    if num = 0 then 0
    else (num % 10) + sumDigitsUp (num / 10)

let sumDigitsDown num =
    let rec sumDigitsDownLoop accomul num =
        if num = 0 then accomul
        else sumDigitsDownLoop (accomul + num % 10) (num / 10)
    sumDigitsDownLoop 0 num



[<EntryPoint>]
let main argv = 
    Console.Write("Введите число: ")
    let num = Console.ReadLine() |> int
    Console.WriteLine($"Сумма цифр числа (вверх): {sumDigitsUp num}")
    Console.WriteLine($"Сумма цифр числа (вниз): {sumDigitsDown num}")


    0



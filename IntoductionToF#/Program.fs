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

[<EntryPoint>]
let main argv = 
    let res = solve 5 52 3
    match res with
         None -> Console.WriteLine("Нет решений")
         | Linear(x) -> Console.WriteLine($"Линейное уравнение, корень: {x}.")
         | Quadratic(x1, x2) -> Console.WriteLine($"Квадратичное уравнение, корни: {x1}, {x2}.")


    0



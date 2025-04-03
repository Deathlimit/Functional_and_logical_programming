open System


let sumDigitsDown num =
    let rec sumDigitsDownLoop accomul num =
        if num = 0 then accomul
        else sumDigitsDownLoop (accomul + num % 10) (num / 10)
    sumDigitsDownLoop 0 num

let factDigit num =
    let rec factDigitLoop mult num =
        if num = 0 then mult
        else factDigitLoop (mult * num) (num - 1)
    factDigitLoop 1 num


let SumOrFact flag =
    match flag with
    | true -> sumDigitsDown
    | false -> factDigit

let rec thingsDigits num (func: int->int->int) acc =
    match num with
    | 0 -> acc
    | someth -> thingsDigits (someth / 10) func (func acc (abs(someth) % 10))

let rec thingsDigitsCondition num (func: int->int->int) acc (condition: int->bool) =
    match num with 
    | 0 -> acc
    | someth ->
        let digit = someth % 10
        let flag = condition digit
        match flag with
        | true -> thingsDigitsCondition (someth / 10) func (func acc (someth % 10)) condition
        | false -> thingsDigitsCondition (someth / 10) func acc condition





[<EntryPoint>]
let main argv = 
    Console.Write("Введите число: ")
    let num = Console.ReadLine() |> int
    Console.WriteLine($"Сумма цифр, которые больше 5: {thingsDigitsCondition num (fun x y -> (x + y)) 0 (fun z -> z > 5)}")
    Console.WriteLine($"Произведение цифр, которые меньше 3: {thingsDigitsCondition num (fun x y -> (x * y)) 1 (fun z -> z < 3)}")
    Console.WriteLine($"Максимальное чётное число: {thingsDigitsCondition num (fun x y -> if x > y then x else y) 0 (fun z -> z % 2 = 0)}")
    Console.WriteLine($"Минимальное нечётное число: {thingsDigitsCondition num (fun x y -> if x < y then x else y) 10 (fun z -> z % 2 <> 0)}")

    0



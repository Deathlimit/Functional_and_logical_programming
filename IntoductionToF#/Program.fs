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
    | someth -> thingsDigits (someth / 10) func (func acc (someth % 10))





[<EntryPoint>]
let main argv = 
    Console.Write("Введите число: ")
    let num = Console.ReadLine() |> int
    Console.WriteLine($"Сумма: {thingsDigits num (fun x y -> x + y) 0  }")
    Console.WriteLine($"Произведение: {thingsDigits num (fun x y -> x * y) 1  }")
    Console.WriteLine($"Максимальный: {thingsDigits num (fun x y -> if x > y then x else y) 0 }")
    Console.WriteLine($"Минимальный: {thingsDigits num (fun x y -> if x < y then x else y) 10 }")


    0



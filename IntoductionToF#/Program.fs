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

let chooseLanguage lang =
    match lang with
    | "F#" -> "Podliza"
    | "Prolog" -> "Ultra podliza"
    | "Ruby" -> ":))"
    | someth -> "Kryto"

let chooseLanguageSuperPos () = 
    Console.Write("Введите любимый язык: ")
    (Console.ReadLine >> chooseLanguage >> Console.WriteLine)

let chooseLanguageCurry () = 
    Console.Write("Введите любимый язык: ")
    let subChooseLanguageCurry reader func writer =
        let answer = reader()
        let langResult = func answer
        writer langResult
    subChooseLanguageCurry Console.ReadLine chooseLanguage Console.WriteLine

let rec gcd x y = 
    match y with
    | 0 -> x
    | someth -> gcd y (x%y)




let obhodProst num (func: int->int->int) init  =
    let rec obhodProstLoop num func acc current =
        match current with
        | 0 -> acc
        | someth ->
            let newAcc =
                let result = gcd num current
                match result with
                | 1 -> func acc current
                | _ -> acc
            obhodProstLoop num func newAcc (current - 1)
    obhodProstLoop num func init num


let EulerFinder num = 
    obhodProst num (fun x y -> x + 1) 0





[<EntryPoint>]
let main argv = 
    Console.Write("Введите число: ")
    let num = Console.ReadLine() |> int
    Console.WriteLine($"Сумма: {obhodProst num (fun x y -> x + y) 0  }")
    Console.WriteLine($"Произведение: {obhodProst num (fun x y -> x * y) 1  }")
    Console.WriteLine($"Максимальный: {obhodProst num (fun x y -> if x > y then x else y) 0 }")
    Console.WriteLine($"Минимальный: {obhodProst num (fun x y -> if x < y then x else y) 10 }")
    Console.WriteLine($"Эйлер: {EulerFinder num}")

    

    0



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





[<EntryPoint>]
let main argv = 
    Console.Write("Введите любимый язык: ")
    let answer = Console.ReadLine() |> string
    let langResult = chooseLanguage answer
    Console.WriteLine(langResult)
    

    0



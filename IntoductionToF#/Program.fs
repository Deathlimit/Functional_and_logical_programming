﻿open System


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

let obhodProstCondition num (func: int->int->int) init (condition: int -> bool)  =
    let rec obhodProstLoop num func acc current condition =
        match current with
        | 0 -> acc
        | someth ->
            let newAcc =
                let result = gcd num current
                let flag = condition current
                match result, flag with
                | 1, true -> func acc current
                | _, _ -> acc
            obhodProstLoop num func newAcc (current - 1) condition
    obhodProstLoop num func init num condition


let EulerFinder num = 
    obhodProst num (fun x y -> x + 1) 0

let isPrime num =
    if num <= 1 then false
    else
        let rec isPrimeLoop curr =
            match curr with
            | _ when curr * curr > num -> true
            | _ when num % curr = 0 -> false
            | _ -> isPrimeLoop (curr + 1)
        isPrimeLoop 2
 
let maxProstDel num =
     let rec maxProstDelLoop max del =
         match del with
         | _ when del > num -> max
         | _ when (num % del = 0) && (isPrime del) -> maxProstDelLoop del (del+1)
         | _ -> maxProstDelLoop max (del+1)
     maxProstDelLoop 0 2

let maxNeProstDel num =
    let rec maxNeProstDelLoop max del =
        match del with
        | _ when del > num -> max
        | _ when (num % del = 0) && (isPrime del = false) && (del % 2 <> 0) -> maxNeProstDelLoop del (del+1)
        | _ -> maxNeProstDelLoop max (del+1)
    maxNeProstDelLoop 0 2

let multDigitsCondition (condition: int -> bool) num  =
     let rec multDigitsConditionLoop acc num =
         match num with
         | 0 -> acc
         | _ when condition (num % 10) -> multDigitsConditionLoop (acc * (num % 10)) (num / 10)
         | _ -> multDigitsConditionLoop acc (num / 10)
     multDigitsConditionLoop 1 num

let multDigits num =
    let rec multDigitsLoop acc num =
        match num with
        | 0 -> acc
        | _ -> multDigitsLoop (acc * (num % 10)) (num / 10)
    multDigitsLoop 1 num



let findNODDelMult num =
    let Del = maxNeProstDel num
    let Mult = multDigits num
    gcd Del Mult


let chooseFunc ans = 
    match ans with 
    | 1 -> maxProstDel 
    | 2 -> multDigitsCondition (fun x -> if x = 5 then false else true)
    | 3 -> findNODDelMult 
    | _ -> failwith "Ошибка"

let chooseFuncSuperPos =
    chooseFunc >> (fun f -> f) 

let chooseFuncCyrr (ans, num) =
    (chooseFunc ans) num
    



[<EntryPoint>]
let main argv = 
    Console.WriteLine("Введите два числа через пробел:")
    let input = Console.ReadLine().Split()
    let tuple = (int input.[0], int input.[1])
    Console.WriteLine($"Суперпозиция:{(chooseFuncSuperPos (fst tuple)) (snd tuple)}")
    Console.WriteLine($"Каррирование:{chooseFuncCyrr tuple}")



    0



open System

let N = 100000

let primesDoN n =
    let rec filterMult p xs acc =
        match xs with
        | [] -> List.rev acc
        | i :: rest ->
            if i % p = 0 then filterMult p rest acc
            else filterMult p rest (i :: acc)

    let rec resheto xs acc =
        match xs with
        | [] -> List.rev acc
        | p :: rest ->
            if p * p > n then (acc @ xs)
            else resheto (filterMult p rest []) (p :: acc)

    resheto [2 .. n] []


let findPeriod p =
    let rec loop j count =
        if j = 1 then count
        else loop ((j * 10) % p) (count + 1)
    loop (10 % p) 1


let delPeriod period =
    let rec divideByFactor n del =
        if n % del = 0 then divideByFactor (n / del) del
        else n
    
    let without2 = divideByFactor period 2
    divideByFactor without2 5


let sum =
    primesDoN (N - 1)
    |> Seq.filter (fun p -> p >= 7)
    |> Seq.map (fun p ->
        let period = findPeriod p
        let new_period = delPeriod period
        printfn "prost = %d | period = %d | delPeriod = %d" p period new_period
        if new_period > 1 then Some p else None)
    |> Seq.choose id
    |> Seq.fold (+) 10

printfn "Сумма = %d" sum



let s a b = a + b
"123" |> s 


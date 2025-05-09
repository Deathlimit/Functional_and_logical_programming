open System

let N = 100000

let resheto =
    let comp = Array.zeroCreate N
    comp[0] <- true
    comp[1] <- true
    
    let rec markMultiples i j =
        if j < N then
            comp[j] <- true
            markMultiples i (j + i)
    
    let rec markPrimes i =
        let maxI = int (sqrt (float N))
        if i <= maxI then
            if not comp[i] then
                markMultiples i (i * i) 
            markPrimes (i + 1)
    
    markPrimes 2
    
    comp

let comp = resheto 

let findPeriod p =
    let rec loop j count =
        if j = 1 then count
        else loop ((j * 10) % p) (count + 1)
    loop (10 % p) 1

let delPeriod i =
    let rec divideBySmth n Smth =
        if n % Smth = 0 then 
            divideBySmth (n / Smth) Smth 
        else 
            n
    
    let without2 = divideBySmth i 2      
    divideBySmth without2 5              

let sum =
    seq { 7 .. N-1 }
    |> Seq.filter (fun p -> not comp[p])
    |> Seq.map (fun p ->
        let period = findPeriod p
        let new_period = delPeriod period
        Console.WriteLine($"prost = {p} | period = {period} | delPeriod = {new_period}")
        if new_period > 1 then Some p else None)
    |> Seq.choose id
    |> Seq.fold (+) 10

Console.WriteLine($"Сумма = {sum}")

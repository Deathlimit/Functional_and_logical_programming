open System

let isGlobalMax arr index =
    let findMax list =
        let rec loop acc = function
            | [] -> acc
            | head::tail -> loop (max acc head) tail
        match list with
        | [] -> failwith "Пустой лист"
        | head::tail -> loop head tail
        
    let getElement index list =
        let rec loop i = function
            | [] -> failwith "Ошибка, выход за границу"
            | head::tail -> if i = index then head else loop (i + 1) tail
        loop 0 list
        
    let maxVal = findMax arr
    let element = getElement index arr
    element = maxVal

let isGlobalMaxUsingList (arr: int list) index =
    arr 
    |> List.item index   
    |> (=) (List.max arr)

let moveBeforeMinToEndUsingList (arr: int list) =
    match arr with
    | [] -> []
    | _ ->
        let minVal = List.min arr
        let minIndex = List.findIndex (fun x -> x = minVal) arr
        let beforeMin, fromMin = List.splitAt minIndex arr
        fromMin @ beforeMin

let moveBeforeMinToEnd arr =
    let rec findMin currentMin = function
        | [] -> currentMin
        | head::tail -> findMin (min head currentMin) tail

    let rec findMinIndex minVal index = function
        | [] -> -1
        | head::tail -> if head = minVal then index else findMinIndex minVal (index + 1) tail

    let reverseList list =
        let rec loop acc = function
            | [] -> acc
            | head::tail -> loop (head::acc) tail
        loop [] list

    let append list1 list2 =
        let reversedList1 = reverseList list1
        let rec loop acc = function
            | [] -> acc
            | head::tail -> loop (head::acc) tail
        loop list2 reversedList1

    let rec splitAt index acc = function
        | [] -> (reverseList acc, [])
        | head::tail as lst ->
            if index = 0 then (reverseList acc, lst)
            else splitAt (index - 1) (head::acc) tail

    match arr with
    | [] -> []
    | _ ->
        let minVal = findMin 1000 arr
        let minIndex = findMinIndex minVal 0 arr
        if minIndex <= 0 then arr 
        else
            let beforeMin, fromMin = splitAt minIndex [] arr
            append fromMin beforeMin

let findTwoSmallestUsingList (arr: int list) =
    match arr with
    | [] | [_] -> []
    | _ ->
        arr
        |> List.sort          
        |> List.take 2


let findTwoSmallest arr =
    let rec updateMinValues x (min1, min2) =
        match x with
        | _ when x < min1 -> (x, min1) 
        | _ when x < min2 -> (min1, x)
        | _ -> (min1, min2)

    let rec findTwoSmallest acc = function
        | [] -> acc
        | head::tail ->
            let newAcc = updateMinValues head acc
            findTwoSmallest newAcc tail

    match arr with
    | [] | [_] -> []
    | fst::snd::tail ->
        let initial = if fst < snd then (fst, snd) else (snd, fst)
        let (min1, min2) = findTwoSmallest initial tail
        [min1; min2]

let alternateSignsUsingList (arr: int list) =
    let pairs = List.pairwise arr
    let allAlternate = 
        pairs 
        |> List.forall (fun (a, b) -> 
            (a > 0 && b < 0) || (a < 0 && b > 0)
        )
    allAlternate

let alternateSigns arr =
    let rec checkAlternate prev = function
        | [] -> true
        | head::tail ->
            if head = 0 then false
            elif (prev > 0 && head < 0) || (prev < 0 && head > 0) then 
                checkAlternate head tail
            else 
                false
        
    match arr with
    | [] -> true
    | head::tail ->
        if head = 0 then false
        else checkAlternate head tail

let countMinElementsUsingList (arr: int list) =
    let minVal = List.min arr
    arr 
    |> List.filter (fun x -> x = minVal) 
    |> List.length

let countMinElements arr =
    let rec findMin currentMin = function
        | [] -> currentMin
        | head::tail -> findMin (min head currentMin) tail
        
    let rec countOccurr count element = function
        | [] -> count
        | head::tail -> 
            if head = element then countOccurr (count + 1) element tail
            else countOccurr count element tail
        
    match arr with
    | [] -> 0
    | head::tail ->
        let minVal = findMin head tail
        countOccurr 0 minVal arr

let buildNewListUsingList (arr: int list) =
    let sum = List.sum arr
    let length = List.length arr
    let average = float sum / float length
    let maxVal = List.max arr
    arr 
    |> List.filter (fun x -> 
        float x > average && x < maxVal
    )

let buildNewList arr =
    let rec sumList acc = function
        | [] -> acc
        | head::tail -> sumList (acc + head) tail
        
    let rec lengthList acc = function
        | [] -> acc
        | head::tail -> lengthList (acc + 1) tail
        
    let rec maxList currentMax = function
        | [] -> currentMax
        | head::tail -> maxList (max head currentMax) tail

    let reverseList list =
        let rec loop acc = function
            | [] -> acc
            | head::tail -> loop (head::acc) tail
        loop [] list
        
    let rec filterList condition acc = function
        | [] -> reverseList acc
        | head::tail ->
            if condition head then
                filterList condition (head::acc) tail
            else
                filterList condition acc tail
        
    let sum = sumList 0 arr
    let length = lengthList 0 arr
    let average = float sum / float length
    let maxVal = maxList -1000 arr
    let condition x = float x > average && x < maxVal
    filterList condition [] arr


let shuffleWords (input: string) =
    let words = input.Split([|' '|])
    let rnd = Random()
    words 
    |> Array.toList
    |> List.sortBy (fun _ -> rnd.Next()) 
    |> String.concat " "

let medianSort (strings: string list) =
    let rec extractMedians (current: (string * int) list) acc =
        match current with
        | [] -> acc |> List.rev
        | _ ->
            let sorted = current |> List.sortBy snd
            let n = List.length sorted

            let medianIndex = if n % 2 = 0 then (n / 2 - 1) else (n / 2)
            let median = sorted.[medianIndex]

            let remaining = sorted |> List.filter (fun x -> x <> median)
            extractMedians remaining (fst median :: acc)

    let withLengths = strings |> List.map (fun s -> (s, s.Length))
    extractMedians withLengths []

let processList (lst: int list) =
    let list1 = lst |> List.filter (fun x -> x % 2 = 0) |> List.map (fun x -> x / 2)
    let list2 = list1 |> List.filter (fun x -> x % 3 = 0) |> List.map (fun x -> x / 3)
    let list3 = list2 |> List.map (fun x -> x * x)
    let list4 = list3 |> List.filter (fun x -> List.contains x list1)
    let list5 = List.concat [list2; list3; list4]
    (list1, list2, list3, list4, list5)

let pyfagorTriples (lst: int list) =
    lst 
    |> List.allPairs lst 
    |> List.allPairs lst 
    |> List.map (fun (a, (b, c)) -> [a; b; c])
    |> List.filter (fun [a; b; c] -> a < b && b < c && a*a + b*b = c*c)
    |> List.distinct


let list = [1; 2; 3; 4; 5; 6]
System.Console.WriteLine(pyfagorTriples list) 

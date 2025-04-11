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

let list = [5; -3; 1; -2; 4; -1]
System.Console.WriteLine(alternateSignsUsingList list) 
System.Console.WriteLine(alternateSigns list)

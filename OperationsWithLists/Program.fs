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

let list = [5; 3; 1; 2; 4]
System.Console.WriteLine(moveBeforeMinToEndUsingList list) 
System.Console.WriteLine(moveBeforeMinToEnd list)

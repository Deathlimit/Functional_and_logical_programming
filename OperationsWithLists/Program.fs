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

let list = [3; 5; 2]
let index = 1
System.Console.WriteLine(isGlobalMax list index) 
System.Console.WriteLine(isGlobalMaxUsingList list index)

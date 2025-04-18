open System

type Maybe<'a> =
    | Just of 'a
    | Nothing

//функтор
let mapMaybe f maybe =
    match maybe with
    | Just x -> Just (f x)
    | Nothing -> Nothing

//аппликативный функтор
let pureMaybe x = Just x

let applyMaybe maybeF maybeX =
    match maybeF, maybeX with
    | Just f, Just x -> Just (f x)
    | _ -> Nothing

//монада
let bindMaybe m f =
    match m with
    | Just x -> f x
    | Nothing -> Nothing

[<EntryPoint>]
let main argv =
    let testValue = 5
    let testF = fun x -> x + 1
    let testG = fun x -> x * 2

    //функтор
    let law1 = 
        mapMaybe id (Just testValue) = Just testValue
        
    let law2 = 
        mapMaybe (testF >> testG) (Just testValue) = (mapMaybe testF >> mapMaybe testG) (Just testValue)

    //аппликативный функтор
    let law3 = 
        applyMaybe (pureMaybe id) (Just testValue) = Just testValue

    let law4 = 
        applyMaybe (pureMaybe testF) (pureMaybe testValue) = pureMaybe (testF testValue)

    let law5 = 
        let u = Just testF
        applyMaybe u (pureMaybe testValue) = applyMaybe (pureMaybe (fun f -> f testValue)) u

    //монада
    let law6 = 
        bindMaybe (pureMaybe testValue) (fun x -> Just (testF x)) = (fun x -> Just (testF x)) testValue

    let law7 = 
        bindMaybe (Just testValue) pureMaybe = Just testValue

    let law8 = 
        let m = Just testValue
        bindMaybe (bindMaybe m (fun x -> Just (testF x))) (fun x -> Just (testG x)) = 
            bindMaybe m (fun x -> bindMaybe (Just (testF x)) (fun y -> Just (testG y)))

    Console.WriteLine("Проверка законов:")
    Console.WriteLine("Функтор:")
    Console.WriteLine("1. Идентичность: {0}", law1)
    Console.WriteLine("2. Композиция: {0}", law2)
    
    Console.WriteLine("\nАппликативный функтор:")
    Console.WriteLine("3. Идентичность: {0}", law3)
    Console.WriteLine("4. Гомоморфизм: {0}", law4)
    Console.WriteLine("5. Обмен: {0}", law5)
    
    Console.WriteLine("\nМонада:")
    Console.WriteLine("6. Левая идентичность: {0}", law6)
    Console.WriteLine("7. Правая идентичность: {0}", law7)
    Console.WriteLine("8. Ассоциативность: {0}", law8)

    0
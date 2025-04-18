open System

type AgentMessage =
    | Hello of string
    | Minus of int * int
    | Date
    | Quit

let agent = 
    MailboxProcessor.Start(fun inbox ->
        async {
            while true do
                let! message = inbox.Receive()
                match message with
                | Hello name -> Console.WriteLine($"Привет, {name}")
                | Minus (a, b) -> Console.WriteLine($"{a} - {b} = {a - b}")
                | Date -> Console.WriteLine($"Сейчас: {DateTime.Now}")
                | Quit -> Environment.Exit(0)
        }
    )

[<EntryPoint>]
let main argv =
    Console.WriteLine("Примеры работы агента:")
    

    agent.Post(Hello "Даня")
    agent.Post(Minus(10, 5))
    agent.Post(Date)
    
    Async.Sleep(3000) |> Async.RunSynchronously
    agent.Post(Quit)
    agent.Post(Date)
    
    Console.WriteLine("Завершение работы...")

    
    
    0
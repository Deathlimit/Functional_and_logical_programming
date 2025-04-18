open System
open System.Windows.Forms
open System.Drawing


let form = new Form(Text = "Калькулятор", Size = Size(300, 200))

let num1TextBox = new TextBox(Dock = DockStyle.Fill)
let num2TextBox = new TextBox(Dock = DockStyle.Fill)
let operationCombo = new ComboBox(Dock = DockStyle.Fill)
let calculateButton = new Button(Text = "Вычислить", Dock = DockStyle.Fill)
let resultLabel = new Label(Dock = DockStyle.Fill, Text = "Результат: ")


operationCombo.Items.AddRange([| "+"; "-"; "*"; "/" |])
operationCombo.SelectedIndex <- 0


let table = new TableLayoutPanel(ColumnCount = 2, RowCount = 5, Dock = DockStyle.Fill)
table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0f))
table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0f))
[0..4] |> List.iter (fun _ -> table.RowStyles.Add(new RowStyle(SizeType.AutoSize)))


table.Controls.Add(new Label(Text = "Число 1:"), 0, 0)
table.Controls.Add(num1TextBox, 1, 0)
table.Controls.Add(new Label(Text = "Число 2:"), 0, 1)
table.Controls.Add(num2TextBox, 1, 1)
table.Controls.Add(new Label(Text = "Операция:"), 0, 2)
table.Controls.Add(operationCombo, 1, 2)
table.Controls.Add(calculateButton, 0, 3)
table.SetColumnSpan(calculateButton, 2)
table.Controls.Add(resultLabel, 0, 4)
table.SetColumnSpan(resultLabel, 2)


calculateButton.Click.Add(fun _ ->
    let parseNumber text =
        match Double.TryParse text with
        | (true, num) -> Some num
        | _ -> None

    let num1 = parseNumber num1TextBox.Text
    let num2 = parseNumber num2TextBox.Text
    let operation = operationCombo.SelectedItem.ToString()

    match num1, num2 with
    | Some n1, Some n2 ->
        try
            let result = 
                match operation with
                | "+" -> n1 + n2
                | "-" -> n1 - n2
                | "*" -> n1 * n2
                | "/" -> 
                    if n2 = 0.0 then raise (DivideByZeroException())
                    else n1 / n2
                | _ -> failwith "Неизвестная операция"
            
            resultLabel.Text <- sprintf $"Результат: {result}"
            resultLabel.ForeColor <- Color.Black
        with
        | :? DivideByZeroException ->
            resultLabel.Text <- "Ошибка: Деление на ноль!"
            resultLabel.ForeColor <- Color.Red
        | ex ->
            resultLabel.Text <- "Ошибка: " + ex.Message
            resultLabel.ForeColor <- Color.Red
    | _ ->
        resultLabel.Text <- "Ошибка: Некорректный ввод чисел"
        resultLabel.ForeColor <- Color.Red
)

form.Controls.Add(table)
Application.Run(form)
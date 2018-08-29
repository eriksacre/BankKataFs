namespace BankKataFs.Domain

module StatementPrinter =
    let private header =
        "DATE | AMOUNT | BALANCE"
        
    let private format (date, amount, balance) =
        sprintf "%s | %d.00 | %d.00" date amount balance
        
    let private statements transactions =
        let statements = 
            transactions
            |> List.map (fun (date, amount) -> (date, amount, 0))
            |> List.scan (fun (d, a, runningTotal) (date, amount, balance) -> (date, amount, runningTotal + amount)) ("", 0, 0)
        
        statements.Tail
        |> List.map format
        |> List.rev

    let Print (printLine: PrintLine) (transactions: (Date * Amount) list) =
        header 
        |> printLine
        
        transactions 
        |> statements 
        |> List.map printLine
        |> ignore

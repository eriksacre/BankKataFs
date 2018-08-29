namespace BankKataFs.Domain

type Date = string
type Amount = int

type PrintLine = string -> unit
    
type Add = (Date * Amount) -> unit
type GetTransactions = unit -> (Date * Amount) list
    
type GetToday = unit -> Date

type StoreTransaction = Amount -> unit

type Print = (Date * Amount) list -> unit

module Account =
    let Deposit (storeTransaction: StoreTransaction) (amount: Amount) =
        storeTransaction amount
        
    let Withdraw (storeTransaction: StoreTransaction) (amount: Amount) =
        storeTransaction -amount
        
    let PrintStatement (getTransactions: GetTransactions) (print: Print) =
        getTransactions () |> print
        
module Transaction =
    let StoreTransaction (getToday: GetToday) (add: Add) (amount: Amount) =
        (getToday (), amount) |> add

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

module Repository =
    let GetRepo () =
        let mutable transactions = []
    
        let add transaction =
            transactions <- [transaction] |> List.append transactions
            
            
        let getTransactions () =
            transactions
            
        (add, getTransactions)

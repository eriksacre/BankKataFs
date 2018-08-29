// Learn more about F# at http://fsharp.org

open System
open BankKataFs.Domain

let printLine (message: string) = 
    System.Console.WriteLine message
    
let (add, getTransactions) = Repository.GetRepo ()
let now () = System.DateTime.Now
let today () = Clock.GetToday now
let storeTransaction = Transaction.StoreTransaction today add
let print = StatementPrinter.Print printLine
    
module AccountService =
    let Deposit = Account.Deposit storeTransaction
    let Withdraw = Account.Withdraw storeTransaction
    let PrintStatement () = Account.PrintStatement getTransactions print

[<EntryPoint>]
let main argv =
    AccountService.Deposit 1000
    AccountService.Withdraw 100
    AccountService.Deposit 500        
    AccountService.PrintStatement()
    0 // return an integer exit code

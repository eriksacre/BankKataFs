namespace BankKataFs.Domain

type Date = string
type Amount = int

module Console =
    type PrintLine = string -> unit

module Account =
    let Deposit (amount: Amount) =
        ()
        
    let Withdraw (amount: Amount) =
        ()
        
    let PrintStatement (printLine: Console.PrintLine) =
        ()
        

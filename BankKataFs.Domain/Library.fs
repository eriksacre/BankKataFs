namespace BankKataFs.Domain

type DateString = string
type Amount = int

module Console =
    type PrintLine = string -> unit

module Account =
    let Debit (amount: Amount) =
        ()
        
    let Credit (amount: Amount) =
        ()
        
    let PrintStatement (printLine: Console.PrintLine) =
        ()
        

namespace BankKataFs.Domain

type Date = string
type Amount = int

type PrintLine = string -> unit
    
type Add = (Date * Amount) -> unit
    
type GetToday = unit -> Date

module Account =
    let Deposit (getToday: GetToday) (add: Add) (amount: Amount) =
        add (getToday (), amount)
        
    let Withdraw (getToday: GetToday) (add: Add) (amount: Amount) =
        add (getToday (), -amount)
        
    let PrintStatement (printLine: PrintLine) =
        ()
        

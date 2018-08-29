namespace BankKataFs.Domain

type Date = string
type Amount = int

module Console =
    type PrintLine = string -> unit
    
module Repository =
    type Add = (Date * Amount) -> unit
    
module Clock =
    type GetToday = unit -> Date

module Account =
    let Deposit (getToday: Clock.GetToday) (add: Repository.Add) (amount: Amount) =
        add (getToday (), amount)
        
    let Withdraw (getToday: Clock.GetToday) (add: Repository.Add) (amount: Amount) =
        add (getToday (), -amount)
        
    let PrintStatement (printLine: Console.PrintLine) =
        ()
        

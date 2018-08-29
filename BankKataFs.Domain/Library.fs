namespace BankKataFs.Domain

type Date = string
type Amount = int

type PrintLine = string -> unit
    
type Add = (Date * Amount) -> unit
    
type GetToday = unit -> Date

type StoreTransaction = Amount -> unit

module Account =
    let Deposit (storeTransaction: StoreTransaction) (amount: Amount) =
        storeTransaction amount
        
    let Withdraw (storeTransaction: StoreTransaction) (amount: Amount) =
        storeTransaction -amount
        
    let PrintStatement (printLine: PrintLine) =
        ()
        
module Transaction =
    let StoreTransaction (getToday: GetToday) (add: Add) (amount: Amount) =
        add (getToday (), amount)

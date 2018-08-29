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
        print (getTransactions ())
        
module Transaction =
    let StoreTransaction (getToday: GetToday) (add: Add) (amount: Amount) =
        add (getToday (), amount)

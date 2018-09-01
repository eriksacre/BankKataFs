namespace BankKataFs.Domain

type Date = string
type Amount = int

module Amount =
    let EnsureIsPositive amount =
        if amount <= 0 then failwith "Amount must be positive"
        amount
        
    let Negate value =
        -value

type PrintLine = string -> unit
    
type Add = (Date * Amount) -> unit
type GetTransactions = unit -> (Date * Amount) list
    
type GetToday = unit -> Date

type StoreTransaction = Amount -> unit

type Print = (Date * Amount) list -> unit

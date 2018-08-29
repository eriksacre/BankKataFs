namespace BankKataFs.Domain

type Date = string
type Amount = int

type PrintLine = string -> unit
    
type Add = (Date * Amount) -> unit
type GetTransactions = unit -> (Date * Amount) list
    
type GetToday = unit -> Date

type StoreTransaction = Amount -> unit

type Print = (Date * Amount) list -> unit

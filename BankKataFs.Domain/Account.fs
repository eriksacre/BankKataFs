namespace BankKataFs.Domain

module Account =
    let Deposit (storeTransaction: StoreTransaction) (amount: Amount) =
        amount
        |> Amount.EnsureIsPositive
        |> storeTransaction
        
    let Withdraw (storeTransaction: StoreTransaction) (amount: Amount) =
        amount
        |> Amount.EnsureIsPositive
        |> Amount.Negate
        |> storeTransaction
        
    let PrintStatement (getTransactions: GetTransactions) (print: Print) =
        getTransactions ()
        |> print
        

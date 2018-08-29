namespace BankKataFs.Domain

module Account =
    let Deposit (storeTransaction: StoreTransaction) (amount: Amount) =
        amount |> storeTransaction
        
    let Withdraw (storeTransaction: StoreTransaction) (amount: Amount) =
        -amount |> storeTransaction
        
    let PrintStatement (getTransactions: GetTransactions) (print: Print) =
        getTransactions () |> print

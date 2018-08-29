namespace BankKataFs.Domain

module Repository =
    let GetRepo () =
        let mutable transactions = []
    
        let add transaction =
            transactions <- [transaction] |> List.append transactions
            
        let getTransactions () =
            transactions
            
        (add, getTransactions)

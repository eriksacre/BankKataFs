namespace BankKataFs.Domain

module Transaction =
    let StoreTransaction (getToday: GetToday) (add: Add) (amount: Amount) =
        (getToday (), amount) |> add

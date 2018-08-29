namespace BankKataFs.Domain

module Clock =
    let GetToday (clock: unit -> System.DateTime) =
        clock().ToString("dd/MM/yyyy")

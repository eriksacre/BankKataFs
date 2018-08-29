namespace BankKataFs.Tests

open NUnit.Framework
open FsUnit
open BankKataFs.Domain

module AccountTests =
    let [<Test>] ``Depositing an amount stores a transaction`` () =
        let (add, added) = Fake.Set ()
        let today = fun () -> "01/02/2018"
        let storeTransaction = Transaction.StoreTransaction today add
        let deposit = Account.Deposit storeTransaction
        
        deposit 100
        
        added () |> should equal ("01/02/2018", 100)   

    let [<Test>] ``Withdrawing an amount stores a transaction for negative that amount`` () =
        let (add, added) = Fake.Set ()
        let today = fun () -> "01/02/2018"
        let storeTransaction = Transaction.StoreTransaction today add
        let withdraw = Account.Withdraw storeTransaction
        
        withdraw 100
        
        added () |> should equal ("01/02/2018", -100)

(*    let [<Test>] ``PrintStatement prints all transactions`` () =
        let (print, printed) = Fake.Set 
        printStatement()
        
        printed () |> should equal []*)
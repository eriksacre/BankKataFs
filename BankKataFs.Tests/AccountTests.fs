namespace BankKataFs.Tests

open NUnit.Framework
open FsUnit
open BankKataFs.Domain

module AccountDepositTests =
    let setupDeposit () =
        let (add, added) = Fake.Set ()
        let today = fun () -> "01/02/2018"
        let storeTransaction = Transaction.StoreTransaction today add
        let deposit = Account.Deposit storeTransaction
        (deposit, added)
    
    let [<Test>] ``Depositing a positive amount stores a transaction`` () =
        let (deposit, added) = setupDeposit ()
        
        deposit 100
        
        added () |> should equal ("01/02/2018", 100)
        
    let [<Test>] ``Depositing a negative number throws an exception`` () =
        let (deposit, _) = setupDeposit ()

        (fun () -> deposit -1)
        |> should throw typeof<System.Exception>
           
    let [<Test>] ``Depositing zero throws an exception`` () =
        let (deposit, _) = setupDeposit ()

        (fun () -> deposit 0)
        |> should throw typeof<System.Exception>

module AccountWithdrawTests =
    let setupWithdraw () =           
        let (add, added) = Fake.Set ()
        let today = fun () -> "01/02/2018"
        let storeTransaction = Transaction.StoreTransaction today add
        let withdraw = Account.Withdraw storeTransaction
        (withdraw, added)

    let [<Test>] ``Withdrawing a positive amount stores a transaction for negative that amount`` () =
        let (withdraw, added) = setupWithdraw ()
        
        withdraw 100
        
        added () |> should equal ("01/02/2018", -100)
        
    let [<Test>] ``Withdrawing a negative amount should throw an exception`` () =
        let (withdraw, added) = setupWithdraw ()
        
        (fun () -> withdraw -1)
        |> should throw typeof<System.Exception>    

    let [<Test>] ``Withdrawing zero should throw an exception`` () =
        let (withdraw, added) = setupWithdraw ()
        
        (fun () -> withdraw 0)
        |> should throw typeof<System.Exception>    

module AccountPrintStatementTests =
    let [<Test>] ``PrintStatement prints all transactions`` () =
        let (print, printed) = Fake.Set ()
        let getTransactions = fun () -> []
        let printStatement () = Account.PrintStatement getTransactions print
        
        printStatement ()
        
        printed () |> should equal []
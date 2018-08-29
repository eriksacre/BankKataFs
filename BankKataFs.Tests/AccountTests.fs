namespace BankKataFs.Tests

open NUnit.Framework
open FsUnit
open BankKataFs.Domain

module AccountTests =
    let [<Test>] ``Depositing an amount stores a transaction`` () =
        let (add, added) = Fake.Set ("", 0)
        let today = fun () -> "01/02/2018"
        let deposit = Account.Deposit today add
        
        deposit 100
        
        added () |> should equal ("01/02/2018", 100)   

    let [<Test>] ``Withdrawing an amount stores a transaction for negative that amount`` () =
        let (add, added) = Fake.Set ("", 0)
        let today = fun () -> "01/02/2018"
        let withdraw = Account.Withdraw today add
        
        withdraw 100
        
        added () |> should equal ("01/02/2018", -100)

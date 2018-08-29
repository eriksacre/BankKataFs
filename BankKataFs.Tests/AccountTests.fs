namespace BankKataFs.Tests

open NUnit.Framework
open FsUnit
open BankKataFs.Domain

module AccountTests =
    let [<Test>] ``Depositing an amount stores a transaction`` () =
        let (add, added) = Fake.Set ("", 0)
        let today = fun () -> "01/02/2018"
        
        Account.Deposit today add 100
        
        added () |> should equal ("01/02/2018", 100)   

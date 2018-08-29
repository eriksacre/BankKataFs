module BankKataFs.Tests.RepositoryTests

open NUnit.Framework
open FsUnit
open BankKataFs.Domain

module RepositoryTests =
    let [<Test>] ``Adding a transaction to an empty repo results in a repo with one transaction`` () =
        let (add, getTransactions) = Repository.GetRepo ()
    
        add ("01/02/2018", 100) |> ignore
        
        getTransactions () |> should equal [ ("01/02/2018", 100) ]

    let [<Test>] ``Get all transactions in insertion order`` () =
        let (add, getTransactions) = Repository.GetRepo ()
        
        add ("01/01/2018", 1) |> ignore
        add ("02/01/2018", 2) |> ignore
        
        getTransactions () |> should equal [
            ("01/01/2018", 1);
            ("02/01/2018", 2)
        ]
        
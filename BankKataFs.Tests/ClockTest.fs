namespace BankKataFs.Tests

open NUnit.Framework
open FsUnit
open BankKataFs.Domain

module ClockTests =
    let [<Test>] ``GetToday should be formatted dd/MM/yyyy`` () =
        let aDate () = System.DateTime(2018, 03, 10)
        
        let today = Clock.GetToday aDate
        
        today |> should equal "10/03/2018" 
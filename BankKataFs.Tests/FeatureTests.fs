namespace BankKataFs.Tests

open NUnit.Framework
open FsUnit
open BankKataFs.Domain

module Features =
    let (capturePrintLine, capturedOutput) = Console.capture ()
        
    module AccountService =
        let Credit = Account.Credit
        let Debit = Account.Debit
        let PrintStatement () = Account.PrintStatement capturePrintLine
    
    let [<Test>] ``PrintStatement must contain all transactions in reverse chronological order`` () =

        AccountService.Credit 1000
        AccountService.Debit 100
        AccountService.Credit 500        
        AccountService.PrintStatement()
        
        capturedOutput () |> should equal [
            "DATE | AMOUNT | BALANCE";
            "10/04/2014 | 500.00 | 1400.00";
            "02/04/2014 | -100.00 | 900.00";
            "01/04/2014 | 1000.00 | 1000.00" ]

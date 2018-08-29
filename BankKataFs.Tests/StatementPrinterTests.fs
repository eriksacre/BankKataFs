module BankKataFs.Tests.StatementPrinterTests

open NUnit.Framework
open FsUnit
open BankKataFs.Domain

module StatementPrinterTests =
    let [<Test>] ``Prints the header if there are no transactions`` () =
        let (printLine, printed) = Console.Capture ()
        let print = StatementPrinter.Print printLine
        
        print []
        
        printed () |> should equal [ "DATE | AMOUNT | BALANCE" ]

    let [<Test>] ``Prints all transactions in reverse chronological order including a running balance`` () =
        let (printLine, printed) = Console.Capture ()
        let print = StatementPrinter.Print printLine
        
        print [
            ("01/01/2018", 100);
            ("02/01/2018", -50);
            ("03/01/2018", 200)
        ]
        
        printed () |> should equal [
            "DATE | AMOUNT | BALANCE";
            "03/01/2018 | 200.00 | 250.00";
            "02/01/2018 | -50.00 | 50.00";
            "01/01/2018 | 100.00 | 100.00" ]
module BankKataFs.Tests.Console

open NUnit.Framework
open FsUnit

let Capture () =
    let mutable output: string list = []
    
    let capturePrintLine message =
        output <- [message] |> List.append output
    
    let capturedOutput () =
        output
        
    (capturePrintLine, capturedOutput)

let [<Test>] ``capturedOutput should return list of captured strings`` () =
    let (capturePrintLine, capturedOutput) = Capture ()
    capturePrintLine "Line 1"
    capturePrintLine "Line 2"
    
    capturedOutput () |> should equal [ "Line 1"; "Line 2" ]
    
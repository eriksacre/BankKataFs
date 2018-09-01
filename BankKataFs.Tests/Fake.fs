module BankKataFs.Tests.Fake

open NUnit.Framework
open FsUnit

let ReturnValues (listOfValues) =
    let mutable list = listOfValues
    
    let nextValue () =
        match list with
        | head :: rest ->
            list <- rest 
            head
        | [] -> failwith "No more data"
        
    nextValue
    
let Set () =
    let mutable savedValue = None
    
    let setValue value =
        savedValue <- Some value
    
    let getValue () =
        match savedValue with
        | Some v -> v
        | None -> failwith "No value was set"
        
    (setValue, getValue)

let [<Test>] ``ReturnValues returns the configured values one by one`` () =
    let rv = ReturnValues [1;2]
    rv () |> should equal 1
    rv () |> should equal 2
    
let [<Test>] ``ReturnValues throws exception when there are no data values left to return`` () =
    let rv = ReturnValues [1]
    rv () |> should equal 1
    (fun () -> rv () |> ignore)
    |> should (throwWithMessage "No more data") typeof<System.Exception>
    
let [<Test>] ``Set:setValue sets a value to be returned by Set:getValue`` () =
    let (setValue, getValue) = Set ()
    setValue 1
    getValue () |> should equal 1

let [<Test>] ``getValue without prior setValue results in exception`` () =
    let (_, getValue) = Set ()
    (fun () -> getValue () |> ignore)
    |> should (throwWithMessage "No value was set") typeof<System.Exception>

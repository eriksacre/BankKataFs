Outside-In TDD in F# with Acceptance Tests
==========================================

Adapted from [Sandro Mancuso's bank-kata-outsidein-screencast](https://github.com/sandromancuso/bank-kata-outsidein-screencast/blob/master/README.md).
 
### Objective

Learn and practice the double loop of TDD
Test application from outside, identifying side effects
 
### Problem description - Bank kata
 
Create a simple bank application with the following features:

- Deposit into Account
- Withdraw from an Account
- Print a bank statement to the console
 
## Acceptance criteria

Statement should have transactions in the following format:

```
DATE       | AMOUNT  | BALANCE
10/04/2014 |  500.00 | 1400.00
02/04/2014 | -100.00 |  900.00
01/04/2014 | 1000.00 | 1000.00
```

## Starting point and constraints

Start with a module with following function signatures:

```
module AccountService =
    Deposit: Amount -> unit
    Withdraw: Amount -> unit
    PrintStatement: unit -> unit
```

You are not allowed to add any other public functions to this module.

**NOTE:** In order to keep the exercise simple, use an _int-alias (Amount)_ for money and _string-alias (Date)_ for dates.
Also, you can ignore the formatting of the statement (spaces between pipes and words, etc).

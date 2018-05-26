# .NET Tech Challenge - Currency to Words Conversion

.NET Tech Challenge - Currency to Words Conversion Service

## How to Run
To view the simple demo, please checkout to the main branch and run using visual studio 2017

* These codes were developed on a windows 10 machine using visual studio 2017.

## Prerequisites
1. Visual Studio 2017 
1. .Net Framework 4.7
2. NUnit 3.10.1
3. NUnit3TestAdapter 3.10.0
4. NSubstitute 3.1.0
5. Ninject.Web.Common 3.3

## Code Flow

### UI
User input Name, Currency(in numbers) 
jQuery calls Webapi hosted @ http://localhost:60005/api/CurrencyConverter
* Update Converter.js script file if the running directory/port is changed.

### NumberToWordsService (API Service)
1. Validate for Currency min and max values
2. Call CurrencyParser to get dollars and cents
3. Convert Currency to Words
3. . Convert Dollars to Words
3. . . Call Transaltion Service to get text for Number
3. . Convert Cents to Words
3. . . Call Transaltion Service to get text for Number
4. Call CurrencyOutoutFormat service (dollar, cents)
5. Send back converted currency in words

### CurrencyParser
-. Currency Parser Service: Parse Currency to Dollars and Cents

### CurrencyTranslator
-. Currency Transalation Service: Lookup for numbers to text

### CurrencyOutputFormatter
-. Foramt Output Dollars & Cents


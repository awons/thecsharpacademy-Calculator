# The C# Academy: Calculator

See https://www.thecsharpacademy.com/project/11/calculator for more details.

## Requirements

### Rules

* See rules from the tutorial at https://learn.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-console?view=vs-2022

### Challenges

* Create a functionality that will count the amount of times the calculator was used.
* Store a list with the latest calculations. And give the users the ability to delete that list.
* Allow the users to use the results in the list above to perform new calculations.
* Add extra calculations: Square Root, Taking the Power, 10x, Trigonometry functions.

### AI Challenge

* Can you make it so the users can make calculations using their voice?

## Running the game

```bash
dotnet restore
dotnet build
dotnet run --project Calculator
```

## Running tests

```bash
dotnet test
```

## Configuring Azure SDK for Speech Recognizer

Add your subscription details into user secrets like this:

```json
{
  "SpeechRecognizer": {
    "Region": "",
    "SubscriptionKey": ""
  }
}
```

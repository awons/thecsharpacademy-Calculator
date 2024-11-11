using Calculator.Logic;
using Calculator.UI;
using Calculator.UI.ChoiceReader;
using Calculator.UI.Menu;
using Calculator.UI.OperandSource;
using Calculator.UI.Operation;

namespace Calculator.Application;

public class Calculator(
    MainMenu mainMenu,
    IChoiceReader choiceReader,
    OperandSourceSelection operandSourceSelection,
    IKeyAwaiter keyAwaiter,
    OperationSelection operationSelection)
{
    private ResultHistory _resultHistory = new();

    public void Run()
    {
        var shouldQuit = false;
        do
        {
            Console.Clear();
            MenuRenderer.Render(mainMenu);
            var menuChoice = choiceReader.GetChoice<MenuChoices>();
            switch (menuChoice)
            {
                case MenuChoices.Quit:
                    shouldQuit = true;
                    break;
                case MenuChoices.StartNewCalculation:
                    RunCalculation();
                    break;
                case MenuChoices.ClearHistory:
                    ClearHistory();
                    break;
            }
        } while (!shouldQuit);

        Console.WriteLine("Thank you for using the Calculator!");
    }

    private void RunCalculation()
    {
        Console.Clear();
        OperandSourceSelectionRenderer.Render(operandSourceSelection);
        var operandSourceChoice = choiceReader.GetChoice<OperandSources>();

        var leftOperand = 5.0;

        OperationSelectionRenderer.Render(operationSelection);
        var operationChoice = choiceReader.GetChoice<OperationChoice>();

        var operationType = OperationUiToLogicMapper.Map(operationChoice);

        double result;
        if (operationType.RequiresTwoOperands())
        {
            OperandSourceSelectionRenderer.Render(operandSourceSelection);
            var secondOperandSourceChoice = choiceReader.GetChoice<OperandSources>();

            var rightOperand = 7.0;
            result = Operation.Perform(operationType, leftOperand, rightOperand);
        }
        else
        {
            result = Operation.Perform(operationType, leftOperand);
        }

        Console.WriteLine(result);
        keyAwaiter.Wait();
    }

    private void ClearHistory()
    {
        Console.Clear();
        _resultHistory.Clear();
        Console.WriteLine("History cleared. Press any key to continue...");
        keyAwaiter.Wait();
    }
}
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
    OperationSelection operationSelection,
    OperandSourceReaderFactory operandSourceReaderFactory)
{
    private ResultHistory _resultHistory = new();
    private int _usedCount;

    public void Run()
    {
        var shouldQuit = false;
        do
        {
            Console.Clear();
            Console.WriteLine($"You used the calculator {_usedCount} times.");
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

        OperandSources operandSourceChoice;
        if (_usedCount != 0)
        {
            OperandSourceSelectionRenderer.Render(operandSourceSelection);
            operandSourceChoice = choiceReader.GetChoice<OperandSources>();
        }
        else
        {
            operandSourceChoice = OperandSources.Console;
        }

        var leftOperandReader = operandSourceReaderFactory.Create(operandSourceChoice);

        Console.WriteLine("Enter operand:");
        var leftOperand = leftOperandReader.ReadOperand();
        double rightOperand = 0;

        OperationSelectionRenderer.Render(operationSelection);

        var operationChoice = choiceReader.GetChoice<OperationChoice>();
        var operationType = OperationUiToLogicMapper.Map(operationChoice);

        double result;
        if (operationType.RequiresTwoOperands())
        {
            OperandSources secondOperandSourceChoice;
            if (_usedCount != 0)
            {
                OperandSourceSelectionRenderer.Render(operandSourceSelection);
                secondOperandSourceChoice = choiceReader.GetChoice<OperandSources>();
            }
            else
            {
                secondOperandSourceChoice = OperandSources.Console;
            }

            var rightOperandReader = operandSourceReaderFactory.Create(secondOperandSourceChoice);

            if (operationType == OperationTypes.Division)
            {
                Console.WriteLine("Enter operand other than 0:");
                do
                {
                    rightOperand = rightOperandReader.ReadOperand();
                } while (rightOperand == 0);
            }
            else
            {
                Console.WriteLine("Enter operand:");
                rightOperand = rightOperandReader.ReadOperand();
            }

            result = Operation.Perform(operationType, leftOperand, rightOperand);
        }
        else
        {
            result = Operation.Perform(operationType, leftOperand);
        }

        _resultHistory.Add(result);

        if (operationType.RequiresTwoOperands())
        {
            if (double.IsNaN(result))
                Console.WriteLine("{0:0.##} {1} {2:0.##} - This operation will result in an error");
            else
                Console.WriteLine("Your result: {0:0.##} {1} {2:0.##} = {3:0.##}", leftOperand,
                    OperationTypeToPresentationMapper.Map(operationType), rightOperand, result);
        }
        else
        {
            if (double.IsNaN(result))
                Console.WriteLine("{1} {0:0.##} - This operation will result in an error");
            else
                Console.WriteLine("Your result: {1} {0:0.##} = {2:0.##}", leftOperand,
                    OperationTypeToPresentationMapper.Map(operationType), result);
        }

        _usedCount++;
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
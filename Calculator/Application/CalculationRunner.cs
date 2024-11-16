using CalculatorLibrary.Logic;
using CalculatorLibrary.UI;
using CalculatorLibrary.UI.ChoiceReader;
using CalculatorLibrary.UI.OperandSource;
using CalculatorLibrary.UI.Operation;

namespace Calculator.Application;

public class CalculationRunner(
    OperandSourceSelection operandSourceSelection,
    OperationSelection operationSelection,
    OperandSourceReaderFactory operandSourceReaderFactory,
    IChoiceReader choiceReader,
    IKeyAwaiter keyAwaiter)
{
    public void Run(Operations previousOperations)
    {
        Console.Clear();

        var leftOperand = GetLeftOperand(previousOperations);
        var operationType = GetOperation();

        OperationDetails operationDetails;
        if (operationType.RequiresTwoOperands())
        {
            var rightOperand = GetRightOperand(operationType, previousOperations);
            var result = OperationExecutor.Perform(operationType, leftOperand, rightOperand);
            operationDetails = new OperationDetails(leftOperand, operationType, result, rightOperand);
        }
        else
        {
            var result = OperationExecutor.Perform(operationType, leftOperand);
            operationDetails = new OperationDetails(leftOperand, operationType, result);
        }

        OperationDetailsRenderer.Render(operationDetails);
        previousOperations.Add(operationDetails);

        keyAwaiter.Wait();
    }

    private OperationType GetOperation()
    {
        OperationSelectionRenderer.Render(operationSelection);

        var operationChoice = choiceReader.GetChoice<OperationChoice>();
        return OperationUiToLogicMapper.Map(operationChoice);
    }

    private OperandSources GetSourceChoice(Operations previousOperations)
    {
        OperandSources operandSourceChoice;
        OperandSourceSelectionRenderer.Render(operandSourceSelection);
        do
        {
            operandSourceChoice = choiceReader.GetChoice<OperandSources>();
        } while (operandSourceChoice == OperandSources.History && previousOperations.Count == 0);

        return operandSourceChoice;
    }

    private double GetLeftOperand(Operations previousOperations)
    {
        var operandSourceChoice = GetSourceChoice(previousOperations);
        var operandReader = operandSourceReaderFactory.Create(operandSourceChoice, previousOperations);

        Console.WriteLine("Enter operand:");
        return operandReader.ReadOperand();
    }

    private double GetRightOperand(OperationType operationType, Operations previousOperations)
    {
        var operandSourceChoice = GetSourceChoice(previousOperations);
        var operandReader = operandSourceReaderFactory.Create(operandSourceChoice, previousOperations);

        if (operationType == OperationType.Division)
        {
            double rightOperand;
            Console.WriteLine("Enter operand other than 0:");
            do
            {
                rightOperand = operandReader.ReadOperand();
            } while (rightOperand == 0);

            return rightOperand;
        }

        Console.WriteLine("Enter operand:");
        return operandReader.ReadOperand();
    }
}
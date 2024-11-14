using CalculatorLibrary.Logic;
using LogicOperation = CalculatorLibrary.Logic.Operation;

namespace CalculatorLibrary.UI.Operation;

public static class OperationRenderer
{
    public static void Render(LogicOperation operation)
    {
        if (operation.OperationType.RequiresTwoOperands())
            Console.Write(
                $"{operation.LeftOperand} {OperationTypeToPresentationMapper.Map(operation.OperationType)} {operation.RightOperand} = {operation.Result}");
        else
            Console.Write(
                $"{OperationTypeToPresentationMapper.Map(operation.OperationType)} {operation.LeftOperand} = {operation.Result}");
    }
}
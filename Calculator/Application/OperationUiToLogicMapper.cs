using Calculator.Logic;
using Calculator.UI.Operation;

namespace Calculator.Application;

public static class OperationUiToLogicMapper
{
    public static OperationTypes Map(OperationChoice uiChoice)
    {
        return uiChoice switch
        {
            OperationChoice.Addition => OperationTypes.Addition,
            OperationChoice.Subtraction => OperationTypes.Subtraction,
            OperationChoice.Multiplication => OperationTypes.Multiplication,
            OperationChoice.Division => OperationTypes.Division,
            OperationChoice.Power => OperationTypes.Power,
            OperationChoice.SquareRoot => OperationTypes.SquareRoot,
            OperationChoice.X10 => OperationTypes.X10,
            OperationChoice.Sine => OperationTypes.Sine,
            OperationChoice.Cosine => OperationTypes.Cosine,
            OperationChoice.Tangent => OperationTypes.Tangent,
            OperationChoice.Cotangent => OperationTypes.Cotangent,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
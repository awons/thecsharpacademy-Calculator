using Calculator.Logic;
using Calculator.UI.Operation;

namespace Calculator.Application;

public static class OperationTypeToPresentationMapper
{
    public static string Map(OperationTypes operationTypes)
    {
        return operationTypes switch
        {
            OperationTypes.Addition => OperationTypePresentation.Addition,
            OperationTypes.Subtraction => OperationTypePresentation.Subtraction,
            OperationTypes.Multiplication => OperationTypePresentation.Multiplication,
            OperationTypes.Division => OperationTypePresentation.Division,
            OperationTypes.SquareRoot => OperationTypePresentation.SquareRoot,
            OperationTypes.Power => OperationTypePresentation.Power,
            OperationTypes.X10 => OperationTypePresentation.X10,
            OperationTypes.Sine => OperationTypePresentation.Sine,
            OperationTypes.Cosine => OperationTypePresentation.Cosine,
            OperationTypes.Tangent => OperationTypePresentation.Tangent,
            OperationTypes.Cotangent => OperationTypePresentation.Cotangent,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
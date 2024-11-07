namespace Calculator.Logic;

public static class Operation
{
    public static double Perform(OperationTypes operationType, double leftOperand, double rightOperand)
    {
        return operationType switch
        {
            OperationTypes.Addition => leftOperand + rightOperand,
            OperationTypes.Subtraction => leftOperand - rightOperand,
            OperationTypes.Multiplication => leftOperand * rightOperand,
            OperationTypes.Division => leftOperand / rightOperand,
            OperationTypes.Power => Math.Pow(leftOperand, rightOperand),
            _ => throw new ArgumentException()
        };
    }

    public static double Perform(OperationTypes operationType, double leftOperand)
    {
        return operationType switch
        {
            OperationTypes.SquareRoot => Math.Sqrt(leftOperand),
            OperationTypes.X10 => leftOperand * 10,
            OperationTypes.Sine => Math.Sin(leftOperand),
            OperationTypes.Cosine => Math.Cos(leftOperand),
            OperationTypes.Tangent => Math.Tan(leftOperand),
            OperationTypes.Cotangent => Math.Tanh(leftOperand),
            _ => throw new ArgumentException()
        };
    }
}
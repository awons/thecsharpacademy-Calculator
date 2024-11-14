namespace CalculatorLibrary.Logic;

public record Operation(double LeftOperand, OperationType OperationType, double Result, double? RightOperand = null)
{
}
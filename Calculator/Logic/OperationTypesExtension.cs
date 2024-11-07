namespace Calculator.Logic;

public static class OperationTypesExtension
{
    public static bool RequiresTwoOperands(this OperationTypes operationType)
    {
        if (operationType == OperationTypes.Addition || operationType == OperationTypes.Subtraction
                                                     || operationType == OperationTypes.Multiplication ||
                                                     operationType == OperationTypes.Division
                                                     || operationType == OperationTypes.Power)
            return true;

        return false;
    }
}
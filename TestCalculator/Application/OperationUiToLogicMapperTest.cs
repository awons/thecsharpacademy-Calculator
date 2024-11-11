using Calculator.Application;
using Calculator.Logic;
using Calculator.UI.Operation;
using FluentAssertions;

namespace TestCalculator.Application;

public class OperationUiToLogicMapperTest
{
    [Test]
    public void WillMapFromUiToLogic()
    {
        OperationUiToLogicMapper.Map(OperationChoice.Addition).Should().Be(OperationTypes.Addition);
        OperationUiToLogicMapper.Map(OperationChoice.Subtraction).Should().Be(OperationTypes.Subtraction);
        OperationUiToLogicMapper.Map(OperationChoice.Multiplication).Should().Be(OperationTypes.Multiplication);
        OperationUiToLogicMapper.Map(OperationChoice.Division).Should().Be(OperationTypes.Division);
        OperationUiToLogicMapper.Map(OperationChoice.Power).Should().Be(OperationTypes.Power);
        OperationUiToLogicMapper.Map(OperationChoice.SquareRoot).Should().Be(OperationTypes.SquareRoot);
        OperationUiToLogicMapper.Map(OperationChoice.X10).Should().Be(OperationTypes.X10);
        OperationUiToLogicMapper.Map(OperationChoice.Sine).Should().Be(OperationTypes.Sine);
        OperationUiToLogicMapper.Map(OperationChoice.Tangent).Should().Be(OperationTypes.Tangent);
        OperationUiToLogicMapper.Map(OperationChoice.Cotangent).Should().Be(OperationTypes.Cotangent);
    }
}
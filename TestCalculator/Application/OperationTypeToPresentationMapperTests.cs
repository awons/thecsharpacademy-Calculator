using Calculator.Application;
using Calculator.Logic;
using FluentAssertions;

namespace TestCalculator.Application;

public class OperationTypeToPresentationMapperTests
{
    [Test]
    [TestCaseSource(nameof(_cases))]
    public void WillMapToCorrectString((OperationTypes type, string expectedResult) caseTuple)
    {
        OperationTypeToPresentationMapper.Map(caseTuple.type).Should().Be(caseTuple.expectedResult);
    }

    private static (OperationTypes, string)[] _cases =
    [
        (OperationTypes.Addition, "+"),
        (OperationTypes.Subtraction, "-"),
        (OperationTypes.Division, "/"),
        (OperationTypes.Multiplication, "*"),
        (OperationTypes.SquareRoot, "\u221a"),
        (OperationTypes.Power, "^"),
        (OperationTypes.X10, "x10"),
        (OperationTypes.Sine, "sin"),
        (OperationTypes.Cosine, "cos"),
        (OperationTypes.Tangent, "tan"),
        (OperationTypes.Cotangent, "cot")
    ];
}
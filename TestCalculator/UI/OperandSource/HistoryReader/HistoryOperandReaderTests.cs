using Calculator.ConsoleWrapper;
using Calculator.Logic;
using Calculator.UI.OperandSource.HistoryReader;
using FluentAssertions;
using NSubstitute;
using LogicOperation = Calculator.Logic.Operation;

namespace TestCalculator.UI.OperandSource.HistoryReader;

public class HistoryOperandReaderTests
{
    [Test]
    public void WillSelectResultBasedOnIndex()
    {
        var operations = new Operations
        {
            new LogicOperation(10, OperationType.Addition, 20, 10),
            new LogicOperation(10, OperationType.Addition, 30, 20),
            new LogicOperation(20, OperationType.Addition, 40, 20)
        };
        var consoleWrapper = Substitute.For<IConsoleWrapper>();
        consoleWrapper.ReadLine().Returns("2");

        var reader = new HistoryOperandReader(operations, consoleWrapper);
        reader.ReadOperand().Should().Be(30);
    }
}
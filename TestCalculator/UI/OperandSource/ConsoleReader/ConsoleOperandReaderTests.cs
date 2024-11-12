using Calculator.ConsoleWrapper;
using Calculator.UI;
using Calculator.UI.OperandSource.ConsoleReader;
using FluentAssertions;
using NSubstitute;
using NSubstitute.Core;

namespace TestCalculator.UI.OperandSource.ConsoleReader;

public class ConsoleOperandReaderTests
{
    [Test]
    public void WillReturnDoubleWhenProvidedWithCorrectNumericString()
    {
        var consoleWrapper = Substitute.For<IConsoleWrapper>();
        consoleWrapper.ReadLine().Returns("45.5");

        var reader = new ConsoleOperandReader(consoleWrapper, Substitute.For<IKeyAwaiter>());
        reader.ReadOperand().Should().Be(45.5);
    }

    [Test]
    public void WillKeepAskingForInputUntilValidProvided()
    {
        var consoleWrapper = Substitute.For<IConsoleWrapper>();
        consoleWrapper.ReadLine().Returns("a", "ab", "22.a", "45.5");
        var keyAwaiter = Substitute.For<IKeyAwaiter>();
        keyAwaiter.When(x => x.Wait()).Do(x => { });

        var reader = new ConsoleOperandReader(consoleWrapper, keyAwaiter);
        reader.ReadOperand().Should().Be(45.5);
    }
}
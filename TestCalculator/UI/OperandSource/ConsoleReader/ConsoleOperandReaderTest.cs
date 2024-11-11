using Calculator.ConsoleWrapper;
using Calculator.UI.OperandSource.ConsoleReader;
using NSubstitute;

namespace TestCalculator.UI.OperandSource.ConsoleReader;

public class ConsoleOperandReaderTest
{
    [Test]
    public void WillReturnWhenProvidedWithDouble()
    {
        var consoleWrapper = Substitute.For<IConsoleWrapper>();
        var reader = new ConsoleOperandReader(consoleWrapper);

        //TODO Finish
    }
}
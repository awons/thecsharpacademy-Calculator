using Calculator.ConsoleWrapper;

namespace Calculator.UI.OperandSource.ConsoleReader;

public class ConsoleOperandReader(IConsoleWrapper consoleWrapper, IKeyAwaiter keyAwaiter) : IOperandReader
{
    public double ReadOperand()
    {
        Console.WriteLine("Enter operand:");
        var positionLeft = Console.CursorLeft;
        var positionTop = Console.CursorTop;
        while (true)
        {
            if (!double.TryParse(consoleWrapper.ReadLine(), out var operand))
            {
                Console.WriteLine("Invalid operand. Press any key to continue.");
                keyAwaiter.Wait();
                Console.SetCursorPosition(positionLeft, positionTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(positionLeft, positionTop);
                continue;
            }

            return operand;
        }
    }
}
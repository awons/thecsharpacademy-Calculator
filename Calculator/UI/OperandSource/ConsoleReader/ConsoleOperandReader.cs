using Calculator.ConsoleWrapper;

namespace Calculator.UI.OperandSource.ConsoleReader;

public class ConsoleOperandReader(IConsoleWrapper consoleWrapper) : IOperandReader
{
    public double ReadOperand()
    {
        Console.WriteLine("Enter operand:");
        var positionLeft = Console.CursorLeft;
        var positionTop = Console.CursorTop;
        while (true)
        {
            double operand;
            if (!double.TryParse(consoleWrapper.ReadLine(), out operand))
            {
                Console.WriteLine("Invalid operand. Press any key to continue.");
                Console.SetCursorPosition(positionLeft, positionTop);
                Console.Write(new string(' ', Console.WindowWidth - 1));
                Console.SetCursorPosition(positionLeft, positionTop);
            }

            return operand;
        }
    }
}
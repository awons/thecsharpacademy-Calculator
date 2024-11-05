namespace Calculator.ConsoleWrapper;

public interface IConsoleWrapper
{
    public ConsoleKeyInfo ReadKey(bool intercept);

    public string? ReadLine();
}
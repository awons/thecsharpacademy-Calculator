namespace Calculator.UI;

public class ConsoleKeyAwaiter : IKeyAwaiter
{
    public void Wait()
    {
        Console.ReadKey();
    }
}
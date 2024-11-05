using Calculator.ConsoleWrapper;

namespace Calculator.UI.Menu;

public class ConsoleMenuReader(IConsoleWrapper consoleWrapper) : IMenuReader
{
    public MenuChoices GetChoice()
    {
        var positionTop = Console.CursorTop;
        var positionLeft = Console.CursorLeft;
        char choice;
        do
        {
            choice = Console.ReadKey(true).KeyChar;
            Console.SetCursorPosition(positionLeft, positionTop);
            Console.Write(' ');
            Console.SetCursorPosition(positionLeft, positionTop);
        } while (!Enum.IsDefined(typeof(MenuChoices), (int)choice));

        return (MenuChoices)choice;
    }
}
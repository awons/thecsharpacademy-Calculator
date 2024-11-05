using Calculator.UI.Menu;

namespace Calculator;

public class Calculator(MainMenu mainMenu, IMenuReader menuReader)
{
    private ResultHistory _resultHistory = new();

    public void Run()
    {
        var shouldQuit = false;
        do
        {
            Console.Clear();
            MenuRenderer.Render(mainMenu);
            var menuChoice = menuReader.GetChoice();
            switch (menuChoice)
            {
                case MenuChoices.Quit:
                    shouldQuit = true;
                    break;
                case MenuChoices.StartNewCalculation:
                    RunCalculation();
                    break;
                case MenuChoices.ClearHistory:
                    _resultHistory.Clear();
                    break;
            }
        } while (shouldQuit);

        Console.WriteLine("Thank you for using the Calculator!");
    }

    private void RunCalculation()
    {
        _resultHistory.Add(1);
    }
}
using Calculator.UI;
using Calculator.UI.ChoiceReader;
using Calculator.UI.Menu;
using Calculator.UI.OperandSource;

namespace Calculator;

public class Calculator(
    MainMenu mainMenu,
    IChoiceReader choiceReader,
    OperandSourceSelection operandSourceSelection,
    IKeyAwaiter keyAwaiter)
{
    private ResultHistory _resultHistory = new();

    public void Run()
    {
        var shouldQuit = false;
        do
        {
            Console.Clear();
            MenuRenderer.Render(mainMenu);
            var menuChoice = choiceReader.GetChoice<MenuChoices>();
            switch (menuChoice)
            {
                case MenuChoices.Quit:
                    shouldQuit = true;
                    break;
                case MenuChoices.StartNewCalculation:
                    RunCalculation();
                    break;
                case MenuChoices.ClearHistory:
                    ClearHistory();
                    break;
            }
        } while (!shouldQuit);

        Console.WriteLine("Thank you for using the Calculator!");
    }

    private void RunCalculation()
    {
        Console.Clear();
        OperandSourceSelectionRenderer.Render(operandSourceSelection);
        var operandSourceChoice = choiceReader.GetChoice<OperandSources>();
    }

    private void ClearHistory()
    {
        Console.Clear();
        _resultHistory.Clear();
        Console.WriteLine("History cleared. Press any key to continue...");
        keyAwaiter.Wait();
    }
}
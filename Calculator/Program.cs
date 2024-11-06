using Calculator.ConsoleWrapper;
using Calculator.UI;
using Calculator.UI.ChoiceReader;
using Calculator.UI.Menu;
using Calculator.UI.OperandSource;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder()
    .ConfigureServices((services) =>
    {
        services.AddSingleton<MainMenu>();
        services.AddSingleton<IConsoleWrapper, ConsoleWrapper>();
        services.AddSingleton<IChoiceReader, ConsoleChoiceReader>();
        services.AddSingleton<OperandSourceSelection>();
        services.AddSingleton<IKeyAwaiter, ConsoleKeyAwaiter>();
    });
var host = builder.Build();

var calculator = ActivatorUtilities.CreateInstance<Calculator.Calculator>(host.Services);
calculator.Run();
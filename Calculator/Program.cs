using Calculator.ConsoleWrapper;
using Calculator.UI;
using Calculator.UI.ChoiceReader;
using Calculator.UI.Menu;
using Calculator.UI.OperandSource;
using Calculator.UI.OperandSource.ConsoleReader;
using Calculator.UI.Operation;
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
        services.AddSingleton<OperationSelection>();
        services.AddOperandSourceReaderFactory();
    });
var host = builder.Build();

var calculator = ActivatorUtilities.CreateInstance<Calculator.Application.Calculator>(host.Services);
calculator.Run();
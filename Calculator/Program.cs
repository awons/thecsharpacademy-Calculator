using Calculator.ConsoleWrapper;
using Calculator.UI;
using Calculator.UI.Menu;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder()
    .ConfigureServices((services) =>
    {
        services.AddSingleton<MainMenu>();
        services.AddSingleton<IConsoleWrapper, ConsoleWrapper>();
        services.AddSingleton<IMenuReader, ConsoleMenuReader>();
    });
var host = builder.Build();

var calculator = ActivatorUtilities.CreateInstance<Calculator.Calculator>(host.Services);
calculator.Run();
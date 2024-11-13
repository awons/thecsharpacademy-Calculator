using Calculator.UI.OperandSource.ConsoleReader;
using Calculator.UI.OperandSource.HistoryReader;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.UI.OperandSource;

public static class OperandSourceReaderFactoryExtension
{
    public static void AddOperandSourceReaderFactory(this IServiceCollection services)
    {
        services.AddSingleton<ConsoleOperandReader>();
        services.AddSingleton<OperandSourceReaderFactory>();
    }
}
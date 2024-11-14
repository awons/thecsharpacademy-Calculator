using Calculator.UI.OperandSource.ConsoleReader;
using Calculator.UI.OperandSource.HistoryReader;
using Calculator.UI.OperandSource.SpeechReader;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.UI.OperandSource;

public static class OperandSourceReaderFactoryExtension
{
    public static void AddOperandSourceReaderFactory(this IServiceCollection services)
    {
        services.AddSingleton<SpeechRecognizerFactory>();
        services.AddSingleton<ConsoleOperandReader>();
        services.AddSingleton<OperandSourceReaderFactory>();
    }
}
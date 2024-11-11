using Calculator.UI.OperandSource.ConsoleReader;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.UI.OperandSource;

public static class OperandSourceReaderFactoryExtension
{
    public static void AddOperandSourceReaderFactory(this IServiceCollection services)
    {
        services.AddSingleton<IOperandReader, ConsoleOperandReader>();
        services.AddSingleton<Func<IEnumerable<IOperandReader>>>(
            x => () => x.GetService<IEnumerable<IOperandReader>>()!);
        services.AddSingleton<OperandSourceReaderFactory>();
    }
}
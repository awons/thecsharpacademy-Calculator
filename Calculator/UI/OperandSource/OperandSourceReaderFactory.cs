using Calculator.ConsoleWrapper;
using Calculator.Logic;
using Calculator.UI.OperandSource.ConsoleReader;
using Calculator.UI.OperandSource.HistoryReader;
using Calculator.UI.OperandSource.SpeechReader;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.UI.OperandSource;

public class OperandSourceReaderFactory(IServiceProvider serviceProvider)
{
    public IOperandReader Create(OperandSources source, Operations operations)
    {
        return source switch
        {
            OperandSources.Console => serviceProvider.GetService<ConsoleOperandReader>()!,
            OperandSources.History => new HistoryOperandReader(operations,
                serviceProvider.GetService<IConsoleWrapper>()!),
            OperandSources.Speech => new SpeechOperandReader(serviceProvider.GetService<SpeechRecognizerFactory>()!
                .Create()),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
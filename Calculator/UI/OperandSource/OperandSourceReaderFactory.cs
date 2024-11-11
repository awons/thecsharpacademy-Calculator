using Calculator.UI.OperandSource.ConsoleReader;

namespace Calculator.UI.OperandSource;

public class OperandSourceReaderFactory(Func<IEnumerable<IOperandReader>> factory)
{
    public IOperandReader Create(OperandSources source)
    {
        var set = factory();
        return source switch
        {
            OperandSources.Console => set.Where(x => x.GetType() == typeof(ConsoleOperandReader)).First(),
            OperandSources.History => throw new NotImplementedException(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
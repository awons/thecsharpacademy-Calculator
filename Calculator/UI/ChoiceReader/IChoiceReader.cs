namespace Calculator.UI.ChoiceReader;

public interface IChoiceReader
{
    public TChoice GetChoice<TChoice>() where TChoice : Enum;
}
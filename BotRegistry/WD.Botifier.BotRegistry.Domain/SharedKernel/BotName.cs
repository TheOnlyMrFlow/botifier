namespace WD.Botifier.BotRegistry.Domain.SharedKernel;

public class BotName
{
    public BotName(string value)
    {
        Value = value;
    }
    
    public string Value { get; }
}
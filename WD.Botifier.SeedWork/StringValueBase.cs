namespace WD.Botifier.SeedWork;

public abstract class StringValueBase : IStringValue
{
    protected StringValueBase(string value)
    {
        Value = value;
    }
    
    public string Value { get; }
}
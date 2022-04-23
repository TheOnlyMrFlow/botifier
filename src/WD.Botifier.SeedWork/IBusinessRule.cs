namespace WD.Botifier.SeedWork;

public interface IBusinessRule
{
    bool IsBroken();

    string Message { get; }
}
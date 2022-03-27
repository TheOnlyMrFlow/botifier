namespace WD.Botifier.Authentication.Domain.Users;

public class AccessToken
{
    public AccessToken(string value)
    {
        Value = value;
    }
    
    public string Value { get; set; }
}
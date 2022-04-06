namespace WD.Botifier.SharedKernel.Reddit.AppCredentials;

public class RedditPassword
{
    public string Value { get; }
    
    public RedditPassword(string value)
    {
        Value = value;
    }
}
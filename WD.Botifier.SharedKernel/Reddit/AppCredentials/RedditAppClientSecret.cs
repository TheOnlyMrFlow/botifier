namespace WD.Botifier.SharedKernel.Reddit.AppCredentials;

public class RedditAppClientSecret
{
    public string Value { get; }
    
    public RedditAppClientSecret(string value)
    {
        Value = value;
    }
}
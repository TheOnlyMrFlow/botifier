namespace WD.Botifier.BotRegistry.Domain.RedditBots.Credentials;

public class RedditClientSecret
{
    public string Value { get; }
    
    public RedditClientSecret(string value)
    {
        Value = value;
    }
}
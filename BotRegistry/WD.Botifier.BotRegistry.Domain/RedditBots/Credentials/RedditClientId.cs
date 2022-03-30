namespace WD.Botifier.BotRegistry.Domain.RedditBots.Credentials;

public class RedditClientId
{
    public string Value { get; }
    
    public RedditClientId(string value)
    {
        Value = value;
    }
}
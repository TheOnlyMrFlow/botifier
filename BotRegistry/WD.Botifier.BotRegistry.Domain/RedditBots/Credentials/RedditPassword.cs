namespace WD.Botifier.BotRegistry.Domain.RedditBots.Credentials;

public class RedditPassword
{
    public string Value { get; }
    
    public RedditPassword(string value)
    {
        Value = value;
    }
}
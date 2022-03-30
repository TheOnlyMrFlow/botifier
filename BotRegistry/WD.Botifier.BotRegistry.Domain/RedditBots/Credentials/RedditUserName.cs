namespace WD.Botifier.BotRegistry.Domain.RedditBots.Credentials;

public class RedditUserName
{
    public string Value { get; }
    
    public RedditUserName(string value)
    {
        Value = value;
    }
}
namespace WD.Botifier.BotRegistry.Domain.RedditBots;

public class RedditBotName
{
    public RedditBotName(string value)
    {
        Value = value;
    }
    
    public string Value { get; }
}
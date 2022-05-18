using WD.Botifier.SeedWork;

namespace WD.Botifier.BotRegistry.Domain.RedditBots;

public enum ERedditBotExceptionCode
{
    TriggerDoesNotExist,
    TriggerAlreadyHasAWebhookWithThisNameException
}

public abstract class RedditBotException : DomainException
{
    public ERedditBotExceptionCode Code2 => ERedditBotExceptionCode.TriggerDoesNotExist;
    
    public RedditBotException(string code) : base(code)
    {
    }
}

public class TriggerDoesNotExistException : RedditBotException
{
    public TriggerDoesNotExistException() : base("TriggerDoesNotExist")
    {
    }
}

public class TriggerAlreadyHasAWebhookWithThisNameException : RedditBotException
{
    public TriggerAlreadyHasAWebhookWithThisNameException() : base("TriggerAlreadyHasAWebhookWithThisName")
    {
    }
}
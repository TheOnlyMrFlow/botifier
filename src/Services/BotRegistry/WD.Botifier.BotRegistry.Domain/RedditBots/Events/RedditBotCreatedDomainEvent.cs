using WD.Botifier.SeedWork;

namespace WD.Botifier.BotRegistry.Domain.RedditBots.Events;

public class RedditBotCreatedDomainEvent : DomainEvent
{
    public RedditBot RedditBot { get; }

    public RedditBotCreatedDomainEvent(RedditBot redditBot)
    {
        RedditBot = redditBot;
    }
}
using System;
using WD.Botifier.SeedWork;

namespace WD.Botifier.BotRegistry.Domain.RedditBots.Triggers;

public class RedditTriggerId : IIdValue
{
    public static RedditTriggerId NewRedditTriggerId() 
        => new (Guid.NewGuid());

    public RedditTriggerId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }
}
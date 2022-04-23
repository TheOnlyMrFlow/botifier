using System;
using WD.Botifier.SeedWork;

namespace WD.Botifier.BotRegistry.Domain.RedditBots;

public class RedditBotId : IdValueBase
{
    public RedditBotId(Guid value) : base(value) { }
    
    public static RedditBotId NewBotId() => new(Guid.NewGuid());
}
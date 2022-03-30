using System;
using WD.Botifier.SeedWork;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Domain.RedditBots;

public class RedditBot : Entity, IAggregateRoot
{
    public RedditBot(RedditBotId id, UserId ownerId, RedditBotName name, DateTime createdAt)
    {
        Id = id;
        OwnerId = ownerId;
        Name = name;
        CreatedAt = createdAt;
    }
    
    public RedditBotId Id { get; }
    
    public UserId OwnerId { get; }
    
    public RedditBotName Name { get; } 
    
    public DateTime CreatedAt { get; }

    public static RedditBot NewBot(UserId ownerId, RedditBotName name) => new(RedditBotId.NewBotId(), ownerId, name, DateTime.UtcNow);
}
using System;
using WD.Botifier.BotRegistry.Domain.RedditBots.Credentials;
using WD.Botifier.BotRegistry.Domain.SharedKernel;
using WD.Botifier.SeedWork;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Domain.RedditBots;

public class RedditBot : Entity, IAggregateRoot, IBot<RedditBotId>
{
    public RedditBot(RedditBotId id, UserId ownerId, BotName name, RedditBotCredentials credentials, DateTime createdAt)
    {
        Id = id;
        OwnerId = ownerId;
        Name = name;
        Credentials = credentials;
        CreatedAt = createdAt;
    }
    
    public RedditBotId Id { get; }
    
    public UserId OwnerId { get; }
    
    public BotName Name { get; } 
    
    public RedditBotCredentials Credentials { get; private set; }
    
    public DateTime CreatedAt { get; }

    public static RedditBot NewBot(UserId ownerId, BotName name) 
        => new(RedditBotId.NewBotId(), ownerId, name, RedditBotCredentials.EmptyCredentials(), DateTime.UtcNow);
    
    public void SetCredentials(RedditBotCredentials credentials) 
        => Credentials = credentials;
}
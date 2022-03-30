using System;
using MongoDB.Bson.Serialization.Attributes;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.RedditBots.Credentials;
using WD.Botifier.BotRegistry.Domain.SharedKernel;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots;

[BsonIgnoreExtraElements]
public class RedditBotDocument
{
    public RedditBotDocument(RedditBot redditBot)
    {
        Id = redditBot.Id.Value;
        OwnerId = redditBot.OwnerId.Value;
        Name = redditBot.Name.Value;
        Credentials = new RedditBotCredentialsDocument(redditBot.Credentials);
        CreatedAt = redditBot.CreatedAt;
    }

    public int SchemaVersion { get; set; } = 2;
    
    [BsonId]
    public Guid Id { get; set; }
    
    public Guid OwnerId { get; set; }
    
    public string Name { get; set; }
    
    public RedditBotCredentialsDocument? Credentials { get; set; }

    public DateTime CreatedAt { get; set; }

    public RedditBot ToRedditBot() 
        => new (
            new RedditBotId(Id),
            new UserId(OwnerId), 
            new BotName(Name), 
            Credentials?.ToRedditBotCredentials() ?? RedditBotCredentials.EmptyCredentials(),
            CreatedAt);
}
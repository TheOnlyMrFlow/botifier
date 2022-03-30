using System;
using MongoDB.Bson.Serialization.Attributes;
using WD.Botifier.BotRegistry.Domain.RedditBots;
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
        CreatedAt = redditBot.CreatedAt;
    }

    public int SchemaVersion { get; set; } = 1;
    
    [BsonId]
    public Guid Id { get; set; }
    
    public Guid OwnerId { get; set; }
    
    public string Name { get; set; }

    public DateTime CreatedAt { get; set; }

    public RedditBot ToRedditBot() => new (new RedditBotId(Id), new UserId(OwnerId), new RedditBotName(Name), CreatedAt);
}
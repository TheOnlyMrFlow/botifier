using System;
using MongoDB.Bson.Serialization.Attributes;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.RedditBots.Credentials;
using WD.Botifier.BotRegistry.Domain.SharedKernel;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots.PreviousVersions;

[BsonIgnoreExtraElements]
public class RedditBotDocumentV1
{
    public int SchemaVersion { get; set; } = 1;
    
    [BsonId]
    public Guid Id { get; set; }
    
    public Guid OwnerId { get; set; }
    
    public string Name { get; set; }

    public DateTime CreatedAt { get; set; }
}
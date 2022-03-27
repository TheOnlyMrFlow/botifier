using System;
using MongoDB.Bson.Serialization.Attributes;
using WD.Botifier.BotRegistry.Domain.Bots;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.Bots;

[BsonIgnoreExtraElements]
public class BotDocument
{
    public BotDocument(Bot bot)
    {
        Id = bot.Id.Value;
        OwnerId = bot.OwnerId.Value;
        Name = bot.Name.Value;
        CreatedAt = bot.CreatedAt;
    }

    public int SchemaVersion { get; set; } = 1;
    
    [BsonId]
    public Guid Id { get; set; }
    
    public Guid OwnerId { get; set; }
    
    public string Name { get; set; }

    public DateTime CreatedAt { get; set; }

    public Bot ToBot() => new (new BotId(Id), new UserId(OwnerId), new BotName(Name), CreatedAt);
}
using System;
using MongoDB.Bson;
using MongoDB.Driver;
using WD.Botifier.Infra.Persistence.MongoDbSeedWork;
using WD.Botifier.SeedWork;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots.Migrations;

public class RedditBotDocumentV3ToV4DbMigration : SchemaUpgradeMongoDbMigration
{
    public RedditBotDocumentV3ToV4DbMigration(IMongoDatabase database) :  base(database)
    {
    }

    public override string MigrationName => "RedditBotV3ToV4";
    public override DateTime MigrationDate => new(2022, 5, 18, 9, 58, 00);
    
    public override int FromVersion => 3;
    public override int ToVersion => 4;
    
    public override BsonDocument UpgradeDocument(BsonDocument source)
    {
        var upgraded = source.DeepClone().AsBsonDocument;
        foreach (var trigger in source["Triggers"].AsBsonArray)
        {
            trigger["Name"] = $"{trigger["_t"]} {StringExtensions.RandomString(10, StringExtensions.AlphaNumericLowercaseCharacterSet)}";
            foreach (var webhook in trigger["Webhooks"].AsBsonArray)
            {
                var bsonId = new BsonBinaryData(Guid.NewGuid(), GuidRepresentation.Standard);
                webhook["_id"] = bsonId;
            }
        }

        return upgraded;
    }

    public override BsonDocument DowngradeDocument(BsonDocument source)
    {
        var downGraded = source.DeepClone().AsBsonDocument;
        foreach (var trigger in source["Triggers"].AsBsonArray)
        {
            trigger.AsBsonDocument.Remove("Name");
            foreach (var webhook in trigger["Webhooks"].AsBsonArray) 
                webhook.AsBsonDocument.Remove("_id");
        }

        return downGraded;
    }
}
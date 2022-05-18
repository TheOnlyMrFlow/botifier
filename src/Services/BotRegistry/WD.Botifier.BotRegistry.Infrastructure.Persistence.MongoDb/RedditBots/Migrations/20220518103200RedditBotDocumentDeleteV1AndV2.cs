using System;
using MongoDB.Bson;
using MongoDB.Driver;
using WD.Botifier.Infra.Persistence.MongoDbSeedWork;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots.Migrations;

public class RedditBotDocumentDeleteV1AndV2 : MongoDbMigration
{
    public RedditBotDocumentDeleteV1AndV2(IMongoDatabase database) : base(database)
    {
    }

    public override string MigrationName => "RedditBotDeleteV1AndV2";
    public override DateTime MigrationDate => new(2022, 5, 18, 10, 32, 00);
    
    public override void Up()
    {
        Database.GetCollection<BsonDocument>("redditBots").DeleteMany(b => b["SchemaVersion"] == 1 || b["SchemaVersion"] == 2);
    }

    public override void Down()
    {
        
    }
}
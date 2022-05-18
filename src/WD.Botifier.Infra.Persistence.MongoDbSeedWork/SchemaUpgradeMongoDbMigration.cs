using MongoDB.Bson;
using MongoDB.Driver;

namespace WD.Botifier.Infra.Persistence.MongoDbSeedWork;

public abstract class SchemaUpgradeMongoDbMigration : MongoDbMigration
{
    private const string CollectionName = "redditBots";
    
    protected SchemaUpgradeMongoDbMigration(IMongoDatabase database) : base(database)
    {
    }
    
    public abstract int FromVersion { get; }
    public abstract int ToVersion { get; }

    public abstract BsonDocument UpgradeDocument(BsonDocument source);
    public abstract BsonDocument DowngradeDocument(BsonDocument source);

    public override void Up()
    {
        var collection = Database.GetCollection<BsonDocument>(CollectionName);
        var upgradedDocs = collection
            .Find(b => b["SchemaVersion"] == FromVersion)
            .ToEnumerable()
            .Select(source =>
            {
                var upgraded = UpgradeDocument(source);
                upgraded["SchemaVersion"] = ToVersion;
                return upgraded;
            });

        foreach (var doc in upgradedDocs) 
            collection.ReplaceOne(x => x["_id"] == doc["_id"], doc);
    }
    
    public override void Down()
    {
        var collection = Database.GetCollection<BsonDocument>(CollectionName);
        var downGradedDocs = collection
            .Find(b => b["SchemaVersion"] == ToVersion)
            .ToEnumerable()
            .Select(source =>
            {
                var downGraded = DowngradeDocument(source);
                downGraded["SchemaVersion"] = FromVersion;
                return downGraded;
            });

        foreach (var doc in downGradedDocs) 
            collection.ReplaceOne(x => x["_id"] == doc["_id"], doc);
    }
}
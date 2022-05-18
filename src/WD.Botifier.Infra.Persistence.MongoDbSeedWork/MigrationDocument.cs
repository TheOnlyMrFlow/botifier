using MongoDB.Bson.Serialization.Attributes;

namespace WD.Botifier.Infra.Persistence.MongoDbSeedWork;

[BsonIgnoreExtraElements]
public class MigrationDocument
{
    public string Name { get; set; }
    public DateTime AppliedAt { get; set; }
}
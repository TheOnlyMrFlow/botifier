namespace WD.Botifier.Infra.Persistence.MongoDbSeedWork;

public interface IMongoVersionedDocument
{
    public int SchemaVersion { get; }
}
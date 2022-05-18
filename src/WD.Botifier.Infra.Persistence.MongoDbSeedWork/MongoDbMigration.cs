using MongoDB.Driver;

namespace WD.Botifier.Infra.Persistence.MongoDbSeedWork;

public abstract class MongoDbMigration
{
    protected IMongoDatabase Database;

    protected MongoDbMigration(IMongoDatabase database)
    {
        Database = database;
    }

    public abstract string MigrationName { get; }
    
    /// <summary>
    /// The exact creation time of the migration. Migrations are run in chronological order based on this property 
    /// </summary>
    public abstract DateTime MigrationDate { get; }

    public abstract void Up();

    public abstract void Down();
}
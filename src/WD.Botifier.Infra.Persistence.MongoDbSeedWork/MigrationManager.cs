using System.Reflection;
using MongoDB.Driver;

namespace WD.Botifier.Infra.Persistence.MongoDbSeedWork;

public class MigrationManager
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="connectionString">The connection string of the mongoDb database</param>
    /// <param name="databaseName">The name of the mongoDb database</param>
    /// <param name="assemblyName">The full name of the assembly where the migrations to apply are located</param>
    public static void ApplyToLatest(string connectionString, string databaseName, string assemblyName)
    {
        var database = new MongoClient(connectionString).GetDatabase(databaseName);
        var migrationCollection = database.GetCollection<MigrationDocument>("_migrationsHistory");

        var migrationsToApply =
            Assembly
                .Load(assemblyName)
                .GetTypes()
                .Where(t => t.IsAssignableTo(typeof(MongoDbMigration)) && t.IsClass && !t.IsAbstract)
                .Select(t => Activator.CreateInstance(t, database))
                .Cast<MongoDbMigration>()
                .OrderByDescending(migration => migration.MigrationDate)
                .TakeWhile(m => !MigrationHasAlreadyBeenApplied(migrationCollection, m.MigrationName))
                .Reverse()
                .ToList();
        
        foreach (var migration in migrationsToApply)
        {
            migration.Up();
            migrationCollection.InsertOne(new MigrationDocument
            {
                Name = migration.MigrationName,
                AppliedAt = DateTime.UtcNow
            });
        }
    }

    private static bool MigrationHasAlreadyBeenApplied(IMongoCollection<MigrationDocument> migrationCollection, string migrationName) 
        => migrationCollection.Find(m => m.Name == migrationName).FirstOrDefault() is not null;
}
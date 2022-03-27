namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb;

public class BotifierBotRegistryMongoDatabaseSettings
{
    public string? BotsCollectionName { get; set; }
    public string? ConnectionString { get; set; }
    public string? DatabaseName { get; set; }
}
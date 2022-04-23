namespace WD.Botifier.Authentication.Infrastructure.Persistence.MongoDb;

public class BotifierAuthenticationMongoDatabaseSettings
{
    public string? UsersCollectionName { get; set; }
    public string? ConnectionString { get; set; }
    public string? DatabaseName { get; set; }
}
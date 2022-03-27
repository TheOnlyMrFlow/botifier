namespace WD.Botifier.Authentication.Persistence.MongoDb;

public class BotifierAuthenticationMongoDatabaseSettings
{
    public string? UsersCollectionName { get; set; }
    public string? ConnectionString { get; set; }
    public string? DatabaseName { get; set; }
}
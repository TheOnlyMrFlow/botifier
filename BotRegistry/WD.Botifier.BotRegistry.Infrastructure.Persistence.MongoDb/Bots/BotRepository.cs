using System.Threading.Tasks;
using MongoDB.Driver;
using WD.Botifier.BotRegistry.Domain.Bots;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.Bots;

public class BotRepository : IBotRepository
{
    private readonly IMongoCollection<BotDocument> _botCollection;
    
    public BotRepository(BotifierBotRegistryMongoDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);

        _botCollection = database.GetCollection<BotDocument>(settings.BotsCollectionName);
    }

    public async Task<bool> BotNameExistsForOwner(UserId ownerId, BotName botName)
        => await _botCollection.Find(b => b.OwnerId == ownerId.Value && b.Name == botName.Value).AnyAsync();

    public async Task AddAsync(Bot bot)
    {
        var doc = new BotDocument(bot);
        await _botCollection.InsertOneAsync(doc);
    }
}
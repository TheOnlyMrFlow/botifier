using System.Threading.Tasks;
using MongoDB.Driver;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots;

public class RedditBotRepository : IRedditBotRepository
{
    private readonly IMongoCollection<RedditBotDocument> _botCollection;
    
    public RedditBotRepository(BotifierBotRegistryMongoDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);

        _botCollection = database.GetCollection<RedditBotDocument>(settings.RedditBotsCollectionName);
    }

    public async Task<bool> BotNameExistsForOwner(UserId ownerId, RedditBotName redditBotName)
        => await _botCollection.Find(b => b.OwnerId == ownerId.Value && b.Name == redditBotName.Value).AnyAsync();

    public async Task AddAsync(RedditBot redditBot)
    {
        var doc = new RedditBotDocument(redditBot);
        await _botCollection.InsertOneAsync(doc);
    }
}
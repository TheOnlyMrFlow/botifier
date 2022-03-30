using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.SharedKernel;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots;

public class RedditBotRepository : IRedditBotRepository
{
    private readonly IMongoCollection<RedditBotDocument> _redditBotCollection;
    
    public RedditBotRepository(BotifierBotRegistryMongoDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);

        _redditBotCollection = database.GetCollection<RedditBotDocument>(settings.RedditBotsCollectionName);
    }

    public async Task<bool> BotNameExistsForOwner(UserId ownerId, BotName botName)
        => await _redditBotCollection.Find(b => b.OwnerId == ownerId.Value && b.Name == botName.Value).AnyAsync();

    public async Task AddAsync(RedditBot redditBot)
    {
        var doc = new RedditBotDocument(redditBot);
        await _redditBotCollection.InsertOneAsync(doc);
    }

    public Task UpdateAsync(RedditBot bot) 
        => _redditBotCollection.ReplaceOneAsync(b => b.Id == bot.Id.Value, new RedditBotDocument(bot));

    public async Task<RedditBot?> GetAsync(UserId ownerId, RedditBotId botId)
        => (await _redditBotCollection.Find(b => b.OwnerId == ownerId.Value && b.Id == botId.Value).FirstOrDefaultAsync()).ToRedditBot();

    public IEnumerable<RedditBot> Search(IRedditBotRepository.SearchRedditBotOptions options) 
        => _redditBotCollection.Find(b => b.OwnerId == options.OwnerId.Value).ToEnumerable().Select(b => b.ToRedditBot());
}
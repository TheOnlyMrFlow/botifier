using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.SharedKernel.Bots;
using WD.Botifier.SeedWork;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots;

public class RedditBotRepository : IRedditBotRepository
{
    private readonly IMongoCollection<RedditBotDocument> _redditBotCollection;
    private readonly DomainEventBus _domainEventBus;
    
    public RedditBotRepository(BotifierBotRegistryMongoDatabaseSettings settings, DomainEventBus domainEventBus)
    {
        _domainEventBus = domainEventBus;
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);

        _redditBotCollection = database.GetCollection<RedditBotDocument>(settings.RedditBotsCollectionName);
    }

    public async Task<bool> BotNameExistsForOwnerAsync(UserId ownerId, BotName botName)
        => await _redditBotCollection.Find(b => b.OwnerId == ownerId.Value && b.Name == botName.Value).AnyAsync();

    public async Task<RedditBot?> GetAsync(UserId ownerId, RedditBotId botId)
        => (await _redditBotCollection.Find(b => b.OwnerId == ownerId.Value && b.Id == botId.Value).FirstOrDefaultAsync())?.ToRedditBot();

    public IEnumerable<RedditBot> Search(IRedditBotRepository.SearchRedditBotOptions options) 
        => _redditBotCollection.Find(b => b.OwnerId == options.OwnerId.Value).ToEnumerable().Select(b => b.ToRedditBot());
    
    public async Task AddAsync(RedditBot redditBot)
    {
        var doc = new RedditBotDocument(redditBot);
        await _redditBotCollection.InsertOneAsync(doc);
        FlushEvents(redditBot);
    }

    public async Task UpdateAsync(RedditBot redditBot)
    {
        await _redditBotCollection.ReplaceOneAsync(b => b.Id == redditBot.Id.Value, new RedditBotDocument(redditBot));
        FlushEvents(redditBot);
    }

    public void FlushEvents(RedditBot redditBot)
    {
        foreach (var @event in redditBot.DomainEvents) 
            _domainEventBus.Emit(@event);
        
        redditBot.ClearDomainEvents();
    }
}
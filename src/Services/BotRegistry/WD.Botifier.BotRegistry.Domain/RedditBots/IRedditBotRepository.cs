using System.Collections.Generic;
using System.Threading.Tasks;
using WD.Botifier.BotRegistry.Domain.SharedKernel;
using WD.Botifier.BotRegistry.Domain.SharedKernel.Bots;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Domain.RedditBots;

public interface IRedditBotRepository
{
    Task<bool> BotNameExistsForOwnerAsync(UserId ownerId, BotName botName);

    Task AddAsync(RedditBot redditBot);

    Task UpdateAsync(RedditBot redditBot);

    Task<RedditBot?> GetAsync(UserId ownerId, RedditBotId botId);

    IEnumerable<RedditBot> Search(SearchRedditBotOptions options);

    public class SearchRedditBotOptions
    {
        public SearchRedditBotOptions(UserId ownerId)
        {
            OwnerId = ownerId;
        }

        public UserId OwnerId { get; }
    }
}
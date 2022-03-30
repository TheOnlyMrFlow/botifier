using System.Threading.Tasks;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Domain.RedditBots;

public interface IRedditBotRepository
{
    Task<bool> BotNameExistsForOwner(UserId ownerId, RedditBotName redditBotName);
    
    Task AddAsync(RedditBot redditBot);
}
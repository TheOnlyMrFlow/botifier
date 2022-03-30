using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.RedditBots.Credentials;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Application.RedditBots.ListRedditBotsOfOwner;

public class ListRedditBotsOfOwnerQuery : AuthenticatedCommandBase
{
    public ListRedditBotsOfOwnerQuery(UserId userId) : base(userId)
    {
        
    }
}
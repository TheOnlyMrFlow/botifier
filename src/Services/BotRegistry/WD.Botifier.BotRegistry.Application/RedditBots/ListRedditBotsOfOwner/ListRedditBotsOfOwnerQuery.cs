using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Application.RedditBots.ListRedditBotsOfOwner;

public class ListRedditBotsOfOwnerQuery : AuthenticatedCommandBase
{
    public UserId OwnerId { get; }

    public ListRedditBotsOfOwnerQuery(UserId userId, UserId ownerId) : base(userId)
    {
        OwnerId = ownerId;
    }
}
using System;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Application.RedditBots.GetRedditBotDetails;

public class GetRedditBotDetailsQuery : AuthenticatedCommandBase
{
    public GetRedditBotDetailsQuery(UserId userId, UserId ownerId, RedditBotId botId) : base(userId)
    {
        OwnerId = ownerId;
        BotId = botId;
    }

    public UserId OwnerId { get; }
    public RedditBotId BotId { get; }
}
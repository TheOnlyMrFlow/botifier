using System;
using System.Collections.Generic;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.SharedKernel;
using WD.Botifier.SharedKernel.Reddit;

namespace WD.Botifier.BotRegistry.Application.RedditBots.AddNewPostInSubredditTrigger;

public class AddNewPostInSubredditTriggerCommand : IAuthenticatedCommand
{
    public AddNewPostInSubredditTriggerCommand(UserId userId, RedditBotId botId, IEnumerable<SubredditName> subredditNames)
    {
        UserId = userId;
        BotId = botId;
        SubredditNames = subredditNames;
    }
    
    public UserId UserId { get; }
    public RedditBotId BotId { get; }
    public IEnumerable<SubredditName> SubredditNames { get; }
}
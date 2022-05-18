using System;
using System.Collections.Generic;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers;
using WD.Botifier.SharedKernel;
using WD.Botifier.SharedKernel.Reddit;

namespace WD.Botifier.BotRegistry.Application.RedditBots.AddNewPostInSubredditTrigger;

public class AddNewPostInSubredditTriggerCommand : IAuthenticatedCommand
{
    public AddNewPostInSubredditTriggerCommand(UserId userId, RedditBotId botId, RedditTriggerName triggerName, IEnumerable<SubredditName> subredditNames)
    {
        UserId = userId;
        TriggerName = triggerName;
        BotId = botId;
        SubredditNames = subredditNames;
    }
    
    public UserId UserId { get; }
    public RedditBotId BotId { get; }
    public RedditTriggerName TriggerName { get; set; }
    public IEnumerable<SubredditName> SubredditNames { get; }
}
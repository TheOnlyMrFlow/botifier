using System;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Application.RedditBots.AddBotUserNameMentionInCommentTrigger;

public class AddBotUserNameMentionInCommentTriggerCommand : IAuthenticatedCommand
{
    public AddBotUserNameMentionInCommentTriggerCommand(UserId userId, RedditBotId botId, RedditTriggerName triggerName)
    {
        TriggerName = triggerName;
        UserId = userId;
        BotId = botId;
    }
    
    public UserId UserId { get; }
    public RedditTriggerName TriggerName { get; set; }
    public RedditBotId BotId { get; }
}
using System;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.SharedKernel.Webhooks;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Application.RedditBots.AddBotUserNameMentionInCommentTrigger;

public class AddBotUserNameMentionInCommentTriggerCommand : IAuthenticatedCommand
{
    public AddBotUserNameMentionInCommentTriggerCommand(UserId userId, RedditBotId botId)
    {
        UserId = userId;
        BotId = botId;
    }
    
    public UserId UserId { get; }
    public RedditBotId BotId { get; }
}
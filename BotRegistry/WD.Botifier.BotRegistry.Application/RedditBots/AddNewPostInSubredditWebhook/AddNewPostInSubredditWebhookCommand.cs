using System;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.SharedKernel.Webhooks;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Application.RedditBots.AddNewPostInSubredditWebhook;

public class AddBotUserNameMentionInCommentWebhookCommand : IAuthenticatedCommand
{
    public AddBotUserNameMentionInCommentWebhookCommand(UserId userId, RedditBotId botId, WebhookName webhookName, Uri webhookUrl)
    {
        UserId = userId;
        BotId = botId;
        WebhookName = webhookName;
        WebhookUrl = webhookUrl;
    }
    
    public UserId UserId { get; }
    public RedditBotId BotId { get; }
    public WebhookName WebhookName { get; }
    public Uri WebhookUrl { get; }
}
using System;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers;
using WD.Botifier.SharedKernel;
using WD.Botifier.SharedKernel.Webhooks;

namespace WD.Botifier.BotRegistry.Application.RedditBots.AddWebhookToTrigger;

public class AddWebhookToTriggerCommand : IAuthenticatedCommand
{
    public AddWebhookToTriggerCommand(UserId userId, RedditBotId botId, RedditTriggerId triggerId, WebhookName webhookName, Uri webhookUrl)
    {
        UserId = userId;
        BotId = botId;
        TriggerId = triggerId;
        WebhookName = webhookName;
        WebhookUrl = webhookUrl;
    }

    public UserId UserId { get; }
    public RedditBotId BotId { get; }
    public RedditTriggerId TriggerId { get; }
    public WebhookName WebhookName { get; }
    public Uri WebhookUrl { get; }
}
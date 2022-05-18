using System;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers;
using WD.Botifier.SharedKernel;
using WD.Botifier.SharedKernel.Webhooks;

namespace WD.Botifier.BotRegistry.Application.RedditBots.RemoveWebhookFromTrigger;

public class RemoveWebhookFromTriggerCommand : IAuthenticatedCommand
{
    public RemoveWebhookFromTriggerCommand(UserId userId, RedditBotId botId, RedditTriggerId triggerId, WebhookName webhookName)
    {
        UserId = userId;
        BotId = botId;
        TriggerId = triggerId;
        WebhookName = webhookName;
    }

    public UserId UserId { get; }
    public RedditBotId BotId { get; }
    public RedditTriggerId TriggerId { get; }
    public WebhookName WebhookName { get; }
}
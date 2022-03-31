using System;
using WD.Botifier.SeedWork;

namespace WD.Botifier.BotRegistry.Domain.RedditBots.Webhooks;

public class RedditWebhookId : IdValueBase
{
    public RedditWebhookId(Guid value) : base(value)
    {
    }

    public static RedditWebhookId NewWebhookId()
        => new RedditWebhookId(Guid.NewGuid());
}
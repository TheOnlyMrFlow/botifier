using System;
using WD.Botifier.BotRegistry.Domain.SharedKernel.Webhooks;

namespace WD.Botifier.BotRegistry.Domain.RedditBots.Webhooks;

public class Webhook
{
    public Webhook(WebhookName name, Uri url)
    {
        Name = name;
        Url = url;
    }

    public WebhookName Name { get;}
    public Uri Url { get; }
}
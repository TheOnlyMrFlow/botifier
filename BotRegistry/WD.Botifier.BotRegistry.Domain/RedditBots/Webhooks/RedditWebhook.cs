using System;
using OneOf;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers;
using WD.Botifier.BotRegistry.Domain.SharedKernel.Webhooks;

namespace WD.Botifier.BotRegistry.Domain.RedditBots.Webhooks;

public class RedditWebhook<TTrigger> : IWebhook<RedditWebhookId> where TTrigger : IRedditTrigger
{
    public RedditWebhook(RedditWebhookId id, WebhookName name, WebhookSecret secret, Uri url, TTrigger trigger)
    {
        Id = id;
        Name = name;
        Secret = secret;
        Url = url;
        Trigger = trigger;
    }

    public RedditWebhookId Id { get; }
    public WebhookName Name { get;}
    public WebhookSecret Secret { get; }
    public Uri Url { get; }
    public TTrigger Trigger { get; }
    
    public static RedditWebhook<TTrigger> NewRedditWebhook(WebhookName name, Uri url, TTrigger trigger) 
        => new (RedditWebhookId.NewWebhookId(), name, WebhookSecret.NewWebhookSecret(), url, trigger);
}
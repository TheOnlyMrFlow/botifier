using System;
using WD.Botifier.SeedWork;

namespace WD.Botifier.SharedKernel.Webhooks;

public class Webhook : ValueObject
{
    public Webhook(WebhookId id, WebhookName name, Uri url)
    {
        Id = id;
        Name = name;
        Url = url;
    }

    public WebhookId Id { get;}
    public WebhookName Name { get;}
    public Uri Url { get; }

    public static Webhook NewWebhook(WebhookName name, Uri url) 
        => new (new WebhookId(Guid.NewGuid()), name, url);
}
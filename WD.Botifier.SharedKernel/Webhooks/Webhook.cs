using System;
using WD.Botifier.SeedWork;

namespace WD.Botifier.SharedKernel.Webhooks;

public class Webhook : ValueObject
{
    public Webhook(WebhookName name, Uri url)
    {
        Name = name;
        Url = url;
    }

    public WebhookName Name { get;}
    public Uri Url { get; }
}
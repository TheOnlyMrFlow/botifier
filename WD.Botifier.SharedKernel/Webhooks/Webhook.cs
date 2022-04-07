using System;

namespace WD.Botifier.SharedKernel.Webhooks;

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
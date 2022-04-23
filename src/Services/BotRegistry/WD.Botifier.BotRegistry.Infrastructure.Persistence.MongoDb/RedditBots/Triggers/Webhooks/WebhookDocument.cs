using System;
using MongoDB.Bson.Serialization.Attributes;
using WD.Botifier.SharedKernel.Webhooks;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots.Triggers.Webhooks;

[BsonDiscriminator]
public class WebhookDocument
{
    public WebhookDocument(Webhook webhook)
    {
        Name = webhook.Name.Value;
        Url = webhook.Url.ToString();
    }
    
    public string Name { get; set; }
    
    public string Url { get; set; }
    
    public Webhook ToWebhook()
    {
        return new Webhook(new WebhookName(Name), new Uri(Url));
    }
}
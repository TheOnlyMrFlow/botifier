using System;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers;
using WD.Botifier.BotRegistry.Domain.RedditBots.Webhooks;
using WD.Botifier.BotRegistry.Domain.SharedKernel.Webhooks;
using WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots.Triggers;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots.Webhooks;

public abstract class RedditWebhookDocument<TTrigger, TTriggerDoc>
    where TTrigger : IRedditTrigger 
    where TTriggerDoc : RedditTriggerDocument<TTrigger>
{
    protected RedditWebhookDocument(RedditWebhook<TTrigger> redditWebhook)
    {
        Id = redditWebhook.Id.Value;
        Name = redditWebhook.Name.Value;
        Secret = redditWebhook.Secret.Value;
        Url = redditWebhook.Url.ToString();
        Trigger = (TTriggerDoc) Activator.CreateInstance(typeof(TTriggerDoc), redditWebhook.Trigger)!;
    }
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Secret { get; set; }
    public string Url { get; set; }
    public RedditTriggerDocument<TTrigger> Trigger { get; set; }
    
    public RedditWebhook<TTrigger> ToRedditWebhook() 
        => new (new RedditWebhookId(Id), new WebhookName(Name), new WebhookSecret(Secret), new Uri(Url), Trigger.ToRedditTrigger());
}
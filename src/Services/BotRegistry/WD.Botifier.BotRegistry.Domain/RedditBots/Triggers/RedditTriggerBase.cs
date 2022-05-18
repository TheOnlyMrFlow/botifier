using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OneOf;
using OneOf.Types;
using WD.Botifier.SharedKernel.Webhooks;

namespace WD.Botifier.BotRegistry.Domain.RedditBots.Triggers;

public interface IRedditTrigger
{
    RedditTriggerId Id { get; }
    
    RedditTriggerName Name { get; }

    IReadOnlyCollection<Webhook> Webhooks { get; } 
    
    void AddWebhook(Webhook webhook);
    
    void RemoveWebhook(WebhookName webhookName);
}

public abstract class RedditTriggerBase<TSettings> : IRedditTrigger where TSettings : IRedditTriggerSettings
{
    protected RedditTriggerBase(RedditTriggerId id, RedditTriggerName name, TSettings settings, IEnumerable<Webhook> webhooks)
    {
        Id = id;
        Name = name;
        Settings = settings;
        _webhooks = new List<Webhook>(webhooks);
    }
    
    public RedditTriggerId Id { get; }
    
    public RedditTriggerName Name { get; }
    
    public TSettings Settings { get; }

    private readonly ICollection<Webhook> _webhooks;
    public IReadOnlyCollection<Webhook> Webhooks => _webhooks.ToList().AsReadOnly();
    
    public void AddWebhook(Webhook webhook)
    {
        if (_webhooks.Any(wh => wh.Name == webhook.Name))
            throw new TriggerAlreadyHasAWebhookWithThisNameException();
        
        // todo: warning system if 2 webhooks have the same URL

        _webhooks.Add(webhook);
    }
    
    public void RemoveWebhook(WebhookName webhookName)
    {
        var webhookToRemove = _webhooks.FirstOrDefault(wh => wh.Name == webhookName);
        if (webhookToRemove is not null) 
            _webhooks.Remove(webhookToRemove);
    }
}
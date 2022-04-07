using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WD.Botifier.SharedKernel.Webhooks;

namespace WD.Botifier.BotRegistry.Domain.RedditBots.Triggers;

public interface IRedditTrigger
{
    RedditTriggerId Id { get; }

    IReadOnlyCollection<Webhook> Webhooks { get; } 
    
    void AddWebhook(Webhook webhook);
}

public abstract class RedditTriggerBase<TSettings> : IRedditTrigger where TSettings : IRedditTriggerSettings
{
    protected RedditTriggerBase( RedditTriggerId id, TSettings settings, IEnumerable<Webhook> webhooks)
    {
        Settings = settings;
        _webhooks = new List<Webhook>(webhooks);
        Id = id;
    }
    
    public RedditTriggerId Id { get; }
    
    public TSettings Settings { get; }

    private readonly ICollection<Webhook> _webhooks;
    public IReadOnlyCollection<Webhook> Webhooks => _webhooks.ToList().AsReadOnly();
    
    public void AddWebhook(Webhook webhook)
    {
        if (_webhooks.Any(wh => wh.Url == webhook.Url))
            throw new ArgumentException($"Webhook with url {webhook.Url} already exists"); // todo: better exception, or even better: allow to add multiple webhooks with same url but show a warning
        
        _webhooks.Add(webhook);
    }
}
using System;
using OneOf;
using OneOf.Types;
using WD.Botifier.BotRegistry.Domain.RedditBots.Events;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.BotUserNameMentionInComment;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.NewPostInSubreddit;
using WD.Botifier.BotRegistry.Domain.SharedKernel.Bots;
using WD.Botifier.SeedWork;
using WD.Botifier.SharedKernel;
using WD.Botifier.SharedKernel.Reddit.AppCredentials;
using WD.Botifier.SharedKernel.Webhooks;

namespace WD.Botifier.BotRegistry.Domain.RedditBots;

public class RedditBot : Entity, IAggregateRoot, IBot<RedditBotId>
{
    public RedditBot(
        RedditBotId id, 
        UserId ownerId, 
        BotName name, 
        RedditAppCredentials credentials,
        RedditBotTriggerCollection triggers,
        DateTime createdAt)
    {
        Id = id;
        OwnerId = ownerId;
        Name = name;
        Credentials = credentials;
        CreatedAt = createdAt;
        _triggers = triggers;
    }
    
    public RedditBotId Id { get; }
    
    public UserId OwnerId { get; }
    
    public BotName Name { get; } 
    
    public RedditAppCredentials Credentials { get; private set; }
    
    public DateTime CreatedAt { get; }

    private readonly RedditBotTriggerCollection _triggers;
    public RedditBotTriggerReadonlyCollection Triggers => _triggers.AsReadonly();

    public static RedditBot NewBot(UserId ownerId, BotName name)
    {
        var bot = new RedditBot(RedditBotId.NewBotId(), ownerId, name, RedditAppCredentials.EmptyCredentials(), RedditBotTriggerCollection.NewRedditBotTriggerCollection(), DateTime.UtcNow);
        bot.AddDomainEvent(new RedditBotCreatedDomainEvent(bot));
        
        return bot;
    }

    public void SetCredentials(RedditAppCredentials credentials) 
        => Credentials = credentials;

    public BotUserNameMentionInCommentTrigger AddNewTrigger(BotUserNameMentionInCommentTriggerSettings triggerSettings)
    {
        var trigger = BotUserNameMentionInCommentTrigger.NewBotUserNameMentionInCommentTrigger(triggerSettings);
        _triggers.AddTrigger(trigger);
        return trigger;
    }

    public NewPostInSubredditTrigger AddNewTrigger(NewPostInSubredditTriggerSettings triggerSettings)
    {
        var trigger = NewPostInSubredditTrigger.NewNewPostInSubredditTrigger(triggerSettings);
        _triggers.AddTrigger(trigger);
        return trigger;
    }

    public void RemoveTrigger(RedditTriggerId triggerId)
    {
        _triggers.RemoveTrigger(triggerId);
    }
    
    public void AddWebhookToTrigger(RedditTriggerId triggerId, Webhook webhook) 
        => _triggers.AddWebhookToTrigger(triggerId, webhook);
    
    public void RemoveWebhookFromTrigger(RedditTriggerId triggerId, WebhookName webhookName) 
        => _triggers.RemoveWebhookFromTrigger(triggerId, webhookName);
}
using System;
using WD.Botifier.BotRegistry.Domain.RedditBots.Credentials;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.BotUserNameMentionInComment;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.NewPostInSubreddit;
using WD.Botifier.BotRegistry.Domain.SharedKernel.Bots;
using WD.Botifier.SeedWork;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Domain.RedditBots;

public class RedditBot : Entity, IAggregateRoot, IBot<RedditBotId>
{
    public RedditBot(
        RedditBotId id, 
        UserId ownerId, 
        BotName name, 
        RedditBotCredentials credentials,
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
    
    public RedditBotCredentials Credentials { get; private set; }
    
    public DateTime CreatedAt { get; }

    private readonly RedditBotTriggerCollection _triggers;
    public RedditBotTriggerReadonlyCollection Triggers => _triggers.AsReadonly();

    public static RedditBot NewBot(UserId ownerId, BotName name) 
        => new(
            RedditBotId.NewBotId(),
            ownerId, 
            name, 
            RedditBotCredentials.EmptyCredentials(),
            RedditBotTriggerCollection.NewRedditBotTriggerCollection(), 
            DateTime.UtcNow);
    
    public void SetCredentials(RedditBotCredentials credentials) 
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
}
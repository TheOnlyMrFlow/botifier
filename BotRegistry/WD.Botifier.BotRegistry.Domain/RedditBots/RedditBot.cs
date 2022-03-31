using System;
using System.Collections.Generic;
using System.Linq;
using WD.Botifier.BotRegistry.Domain.RedditBots.Credentials;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.BotUserNameMentionInComment;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.NewPostInSubreddit;
using WD.Botifier.BotRegistry.Domain.RedditBots.Webhooks;
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
        ICollection<RedditWebhook<BotUserNameMentionInCommentTrigger>> botUserNameMentionInCommentWebhooks,
        ICollection<RedditWebhook<NewPostInSubredditTrigger>> newPostInSubredditWebhooks,
        DateTime createdAt)
    {
        Id = id;
        OwnerId = ownerId;
        Name = name;
        Credentials = credentials;
        CreatedAt = createdAt;
        _botUserNameMentionInCommentWebhooks = botUserNameMentionInCommentWebhooks;
        _newPostInSubredditWebhooks = newPostInSubredditWebhooks;
    }
    
    public RedditBotId Id { get; }
    
    public UserId OwnerId { get; }
    
    public BotName Name { get; } 
    
    public RedditBotCredentials Credentials { get; private set; }
    
    public DateTime CreatedAt { get; }

    private readonly ICollection<RedditWebhook<BotUserNameMentionInCommentTrigger>> _botUserNameMentionInCommentWebhooks;
    public IReadOnlyCollection<RedditWebhook<BotUserNameMentionInCommentTrigger>> BotUserNameMentionInCommentWebhooks => _botUserNameMentionInCommentWebhooks.ToList().AsReadOnly();
    
    private readonly ICollection<RedditWebhook<NewPostInSubredditTrigger>> _newPostInSubredditWebhooks;
    public IReadOnlyCollection<RedditWebhook<NewPostInSubredditTrigger>> NewPostInSubredditWebhooks => _newPostInSubredditWebhooks.ToList().AsReadOnly();
    
    public static RedditBot NewBot(UserId ownerId, BotName name) 
        => new(
            RedditBotId.NewBotId(),
            ownerId, 
            name, 
            RedditBotCredentials.EmptyCredentials(),
            new List<RedditWebhook<BotUserNameMentionInCommentTrigger>>(),
            new List<RedditWebhook<NewPostInSubredditTrigger>>(),
            DateTime.UtcNow);
    
    public void SetCredentials(RedditBotCredentials credentials) 
        => Credentials = credentials;

    public void AddWebhook(RedditWebhook<BotUserNameMentionInCommentTrigger> webhook) 
        => _botUserNameMentionInCommentWebhooks.Add(webhook);

    public void AddWebhook(RedditWebhook<NewPostInSubredditTrigger> webhook) 
        => _newPostInSubredditWebhooks.Add(webhook);
}
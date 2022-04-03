using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.RedditBots.Credentials;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.BotUserNameMentionInComment;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.NewPostInSubreddit;
using WD.Botifier.BotRegistry.Domain.SharedKernel.Bots;
using WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots.Triggers;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots;

[BsonIgnoreExtraElements]
public class RedditBotDocument
{
    public RedditBotDocument(RedditBot redditBot)
    {
        Id = redditBot.Id.Value;
        OwnerId = redditBot.OwnerId.Value;
        Name = redditBot.Name.Value;
        Credentials = new RedditBotCredentialsDocument(redditBot.Credentials);
        Triggers =
            redditBot.Triggers.NewPostInSubredditTrigger.Select(t => new NewPostInSubredditTriggerDocument(t))
                .Concat<RedditBotTriggerDocumentBase>(redditBot.Triggers.BotUserNameMentionInCommentTrigger.Select(t => new BotUserNameMentionInCommentTriggerDocument(t)))
                .ToList();
        CreatedAt = redditBot.CreatedAt;
    }

    public int SchemaVersion { get; set; } = 3;
    
    [BsonId]
    public Guid Id { get; set; }
    
    public Guid OwnerId { get; set; }
    
    public string Name { get; set; }
    
    public RedditBotCredentialsDocument? Credentials { get; set; }
    
    public ICollection<RedditBotTriggerDocumentBase>? Triggers { get; set; }

    public DateTime CreatedAt { get; set; }

    public RedditBot ToRedditBot() 
        => new (
            new RedditBotId(Id),
            new UserId(OwnerId), 
            new BotName(Name), 
            Credentials?.ToRedditBotCredentials() ?? RedditBotCredentials.EmptyCredentials(),
            new RedditBotTriggerCollection(
                Triggers
                    ?.Where(t => t.Type == BotUserNameMentionInCommentTriggerDocument.TriggerType)
                    .Cast<BotUserNameMentionInCommentTriggerDocument>()
                    .Select(t => t.ToTrigger()) ?? Array.Empty<BotUserNameMentionInCommentTrigger>(),
                Triggers
                    ?.Where(t => t.Type == NewPostInSubredditTriggerDocument.TriggerType)
                    .Cast<NewPostInSubredditTriggerDocument>()
                    .Select(t => t.ToTrigger()) ?? Array.Empty<NewPostInSubredditTrigger>()
                ),
            CreatedAt);
}
using System;
using MongoDB.Bson.Serialization.Attributes;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots.Triggers;

[BsonKnownTypes(typeof(BotUserNameMentionInCommentTriggerDocument), typeof(NewPostInSubredditTriggerDocument))]
public abstract class RedditBotTriggerDocumentBase
{
    public Guid Id { get; set; }
    
    [BsonIgnore]
    public abstract string Type { get; }
}

public abstract class RedditBotTriggerDocumentBase<TSettings> : RedditBotTriggerDocumentBase where TSettings : IRedditBotTriggerSettingsDocument
{
    public TSettings Settings { get; set; }
}

public interface IRedditBotTriggerSettingsDocument
{
    
}
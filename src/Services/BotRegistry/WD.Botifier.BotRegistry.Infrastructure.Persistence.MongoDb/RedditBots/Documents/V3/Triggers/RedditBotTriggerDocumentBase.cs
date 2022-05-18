﻿using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots.Document.V3.Triggers;

[BsonKnownTypes(typeof(BotUserNameMentionInCommentTriggerDocument), typeof(NewPostInSubredditTriggerDocument))]
public abstract class RedditBotTriggerDocumentBase
{
    public Guid Id { get; set; }
    
    public ICollection<WebhookDocument>? Webhooks { get; set; }

    [BsonIgnore]
    public abstract string Type { get; }
}

public abstract class RedditBotTriggerDocumentBase<TSettings> : RedditBotTriggerDocumentBase where TSettings : IRedditBotTriggerSettingsDocument
{
    public RedditBotTriggerDocumentBase(IRedditTrigger trigger, TSettings settings)
    {
        Id = trigger.Id.Value;
        Latest.Triggers.Webhooks = trigger.Webhooks.Select(wh => new WebhookDocument(wh)).ToList();
        Settings = settings;
    }
    
    public TSettings Settings { get; set; }
}

public interface IRedditBotTriggerSettingsDocument
{
    
}
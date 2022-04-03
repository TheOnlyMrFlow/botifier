using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.BotUserNameMentionInComment;
using WD.Botifier.BotRegistry.Domain.RedditBots.Webhooks;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots.Triggers;

[BsonDiscriminator(TriggerType)]
public class BotUserNameMentionInCommentTriggerDocument : RedditBotTriggerDocumentBase<BotUserNameMentionInCommentTriggerSettingsDocument>
{
    public const string TriggerType = "BotUserNameMentionInComment";
    
    public BotUserNameMentionInCommentTriggerDocument(BotUserNameMentionInCommentTrigger trigger)
    {
        Settings = new BotUserNameMentionInCommentTriggerSettingsDocument(trigger.Settings);
    }
    
    public BotUserNameMentionInCommentTrigger ToTrigger()
        => new (new RedditTriggerId(Id), Settings.ToSettings(), new List<Webhook>());

    public override string Type => TriggerType;
}

public class BotUserNameMentionInCommentTriggerSettingsDocument : IRedditBotTriggerSettingsDocument
{
    public BotUserNameMentionInCommentTriggerSettingsDocument(BotUserNameMentionInCommentTriggerSettings settings)
    {
    }

    public BotUserNameMentionInCommentTriggerSettings ToSettings()
        => new ();
}
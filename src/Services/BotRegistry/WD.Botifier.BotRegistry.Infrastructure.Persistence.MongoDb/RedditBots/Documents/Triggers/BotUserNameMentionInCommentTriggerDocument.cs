using MongoDB.Bson.Serialization.Attributes;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.BotUserNameMentionInComment;
using WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots.Documents.Triggers.Webhooks;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots.Documents.Triggers;

[BsonIgnoreExtraElements]
[BsonDiscriminator(TriggerType)]
public class BotUserNameMentionInCommentTriggerDocument : RedditBotTriggerDocumentBase<BotUserNameMentionInCommentTriggerSettingsDocument>
{
    public const string TriggerType = "BotUserNameMentionInComment";
    
    public BotUserNameMentionInCommentTriggerDocument(BotUserNameMentionInCommentTrigger trigger) 
        : base(trigger, new BotUserNameMentionInCommentTriggerSettingsDocument(trigger.Settings))
    {
    }

    public BotUserNameMentionInCommentTrigger ToTrigger()
        => new (new RedditTriggerId(Id), new RedditTriggerName(Name), Settings.ToSettings(), Webhooks.ToWebhooks());

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
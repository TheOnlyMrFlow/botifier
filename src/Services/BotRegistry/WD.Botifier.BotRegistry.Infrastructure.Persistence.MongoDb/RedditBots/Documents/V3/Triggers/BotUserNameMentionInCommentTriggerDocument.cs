using MongoDB.Bson.Serialization.Attributes;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.BotUserNameMentionInComment;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots.Document.V3.Triggers;

[BsonDiscriminator(TriggerType)]
public class BotUserNameMentionInCommentTriggerDocument : RedditBotTriggerDocumentBase<BotUserNameMentionInCommentTriggerSettingsDocument>
{
    public const string TriggerType = "BotUserNameMentionInComment";
    
    public BotUserNameMentionInCommentTriggerDocument(BotUserNameMentionInCommentTrigger trigger) 
        : base(trigger, new BotUserNameMentionInCommentTriggerSettingsDocument(trigger.Settings))
    {
    }

    public BotUserNameMentionInCommentTrigger ToTrigger()
        => new (new RedditTriggerId(Id), Settings.ToSettings(), Latest.Triggers.Webhooks.ToWebhooks());

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
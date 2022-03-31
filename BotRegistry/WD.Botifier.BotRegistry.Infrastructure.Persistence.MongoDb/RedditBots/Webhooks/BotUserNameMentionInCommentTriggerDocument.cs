using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.BotUserNameMentionInComment;
using WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots.Triggers;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots.Webhooks;

public class BotUserNameMentionInCommentTriggerDocument : RedditTriggerDocument<BotUserNameMentionInCommentTrigger>
{
    public BotUserNameMentionInCommentTriggerDocument(BotUserNameMentionInCommentTrigger trigger) : base(trigger)
    {
    }

    public override BotUserNameMentionInCommentTrigger ToRedditTrigger() 
        => new ();
}
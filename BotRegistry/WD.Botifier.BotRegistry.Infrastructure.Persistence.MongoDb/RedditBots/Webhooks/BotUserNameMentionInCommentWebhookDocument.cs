using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.BotUserNameMentionInComment;
using WD.Botifier.BotRegistry.Domain.RedditBots.Webhooks;
using WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots.Triggers;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots.Webhooks;

public class BotUserNameMentionInCommentWebhookDocument : RedditWebhookDocument<BotUserNameMentionInCommentTrigger, BotUserNameMentionInCommentTriggerDocument>
{
    public BotUserNameMentionInCommentWebhookDocument(RedditWebhook<BotUserNameMentionInCommentTrigger> redditWebhook) : base(redditWebhook)
    {
    }
}
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.NewPostInSubreddit;
using WD.Botifier.BotRegistry.Domain.RedditBots.Webhooks;
using WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots.Webhooks;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots.Triggers;

public class NewPostInSubredditWebhookDocument : RedditWebhookDocument<NewPostInSubredditTrigger, NewPostInSubredditTriggerDocument>
{
    public NewPostInSubredditWebhookDocument(RedditWebhook<NewPostInSubredditTrigger> redditWebhook) : base(redditWebhook)
    {
    }
}
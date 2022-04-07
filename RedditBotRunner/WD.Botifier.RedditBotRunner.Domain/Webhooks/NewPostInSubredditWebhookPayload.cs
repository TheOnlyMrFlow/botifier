using WD.Botifier.RedditBotRunner.Domain.Triggers;

namespace WD.Botifier.RedditBotRunner.Domain.Webhooks;

public class NewPostInSubredditWebhookPayload : IWebhookPayload
{
    public NewPostInSubredditWebhookPayload(NewPostInSubredditTriggerMatch triggerMatch)
    {
        TriggerType = "NewPostInSubreddit";
        TriggeredOn = DateTime.UtcNow;
        Subreddit = triggerMatch.Post.Subreddit.WithoutRSlash;
        PostTitle = triggerMatch.Post.Title.Value;
    }

    public string TriggerType { get; }
    public DateTime TriggeredOn { get; }
    public string Subreddit { get; }
    public string PostTitle { get; }
}
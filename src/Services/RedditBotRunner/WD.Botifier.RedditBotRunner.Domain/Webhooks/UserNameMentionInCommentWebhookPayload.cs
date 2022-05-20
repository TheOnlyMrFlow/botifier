using WD.Botifier.RedditBotRunner.Domain.Bots.Triggers.UserNameMentionInComment;

namespace WD.Botifier.RedditBotRunner.Domain.Webhooks;

public class UserNameMentionInCommentWebhookPayload : IWebhookPayload
{
    public UserNameMentionInCommentWebhookPayload(UserNameMentionInCommentTriggerMatch triggerMatch)
    {
        TriggerType = "UserNameMentionInComment";
        TriggeredOn = DateTime.UtcNow;
        CommentAuthor = triggerMatch.Comment.Author.WithoutUSlash;
        CommentContent = triggerMatch.Comment.Content.Value;
    }

    public string TriggerType { get; }
    public DateTime TriggeredOn { get; }
    public string CommentAuthor { get; }
    public string CommentContent { get; }
}
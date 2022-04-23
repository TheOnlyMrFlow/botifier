using WD.Botifier.SharedKernel.Reddit.Comments;
using WD.Botifier.SharedKernel.Webhooks;

namespace WD.Botifier.RedditBotRunner.Domain.Triggers.UserNameMentionInComment;

public class UserNameMentionInCommentTrigger : TriggerBase
{
    public UserNameMentionInCommentTrigger(TriggerId id, Guid redditBotId, IEnumerable<Webhook> webhooks) : base(id, redditBotId, webhooks)
    {
    }

    public UserNameMentionInCommentTriggerMatch Match(RedditComment comment) => new (this, comment);
}
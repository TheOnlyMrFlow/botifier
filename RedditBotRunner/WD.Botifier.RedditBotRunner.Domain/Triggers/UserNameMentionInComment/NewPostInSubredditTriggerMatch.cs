using WD.Botifier.SharedKernel.Reddit.Comments;

namespace WD.Botifier.RedditBotRunner.Domain.Triggers.UserNameMentionInComment;

public class UserNameMentionInCommentTriggerMatch
{
    public UserNameMentionInCommentTriggerMatch(UserNameMentionInCommentTrigger trigger, RedditComment comment)
    {
        Trigger = trigger;
        Comment = comment;
    }

    public UserNameMentionInCommentTrigger Trigger { get; }
    
    public RedditComment Comment { get; }
}
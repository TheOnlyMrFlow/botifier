using WD.Botifier.SharedKernel.Reddit.Comments;

namespace WD.Botifier.RedditBotRunner.Domain.Intents;

public class ReplyToCommentIntent
{
    public RedditCommentId CommentId { get; set; }
    public RedditCommentContent Reply { get; set; }
}
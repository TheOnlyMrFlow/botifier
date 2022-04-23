using WD.Botifier.SharedKernel.Reddit.Posts;

namespace WD.Botifier.RedditBotRunner.Domain.Intents;

public class ReplyToPostIntent
{
    public RedditPostId PostId { get; set; }
    public RedditPostContent Reply { get; set; }
}
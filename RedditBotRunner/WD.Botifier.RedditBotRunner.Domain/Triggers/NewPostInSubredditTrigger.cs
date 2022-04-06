using WD.Botifier.SharedKernel.Reddit;

namespace WD.Botifier.RedditBotRunner.Domain.Triggers;

public class NewPostInSubredditTrigger : TriggerBase
{
    public SubredditName Subreddit { get; set; }
}
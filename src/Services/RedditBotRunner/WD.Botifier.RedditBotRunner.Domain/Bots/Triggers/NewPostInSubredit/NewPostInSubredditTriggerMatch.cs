using WD.Botifier.SharedKernel.Reddit.Posts;

namespace WD.Botifier.RedditBotRunner.Domain.Bots.Triggers.NewPostInSubredit;

public class NewPostInSubredditTriggerMatch
{
    public NewPostInSubredditTriggerMatch(NewPostInSubredditTrigger trigger, RedditPost post)
    {
        Trigger = trigger;
        Post = post;
    }

    public NewPostInSubredditTrigger Trigger { get; }
    
    public RedditPost Post { get; }
}
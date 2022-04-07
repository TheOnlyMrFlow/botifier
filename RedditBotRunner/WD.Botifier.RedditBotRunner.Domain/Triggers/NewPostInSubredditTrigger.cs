using WD.Botifier.SharedKernel.Reddit;
using WD.Botifier.SharedKernel.Reddit.Posts;
using WD.Botifier.SharedKernel.Webhooks;

namespace WD.Botifier.RedditBotRunner.Domain.Triggers;

public class NewPostInSubredditTrigger : TriggerBase
{
    public NewPostInSubredditTrigger(TriggerId id, Guid redditBotId, IEnumerable<Webhook> webhooks, ICollection<SubredditName> subreddits) : base(id, redditBotId, webhooks)
    {
        Subreddits = subreddits;
    }
    
    public ICollection<SubredditName> Subreddits { get; }

    public NewPostInSubredditTriggerMatch Match(RedditPost post) => new (this, post);
}

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
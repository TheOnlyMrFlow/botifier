using System.Collections;
using System.Collections.Generic;
using WD.Botifier.SharedKernel.Reddit;

namespace WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.NewPostInSubreddit;

public class NewPostInSubredditTriggerSettings : IRedditTriggerSettings
{
    public NewPostInSubredditTriggerSettings(IEnumerable<SubredditName> subreddits)
    {
        Subreddits = new List<SubredditName>(subreddits);
    }

    public ICollection<SubredditName> Subreddits { get; }
}
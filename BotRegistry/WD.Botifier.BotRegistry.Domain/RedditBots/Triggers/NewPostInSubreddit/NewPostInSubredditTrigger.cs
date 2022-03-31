using System.Collections.Generic;
using WD.Botifier.SharedKernel.Reddit;

namespace WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.NewPostInSubreddit;

public class NewPostInSubredditTrigger : IRedditTrigger
{
    public NewPostInSubredditTrigger(IEnumerable<SubredditName> subredditNames)
    {
        SubredditNames = new List<SubredditName>(subredditNames);
    }

    public ICollection<SubredditName> SubredditNames { get; }
}
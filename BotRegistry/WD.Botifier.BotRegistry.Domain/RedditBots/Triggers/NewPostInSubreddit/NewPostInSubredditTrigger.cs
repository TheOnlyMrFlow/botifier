using System;
using System.Collections.Generic;
using WD.Botifier.BotRegistry.Domain.RedditBots.Webhooks;

namespace WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.NewPostInSubreddit;

public class NewPostInSubredditTrigger : RedditTriggerBase<NewPostInSubredditTriggerSettings>
{
    public static NewPostInSubredditTrigger NewNewPostInSubredditTrigger(NewPostInSubredditTriggerSettings settings)
        => new(RedditTriggerId.NewRedditTriggerId(), settings, new List<Webhook>());
    
    public NewPostInSubredditTrigger(RedditTriggerId id, NewPostInSubredditTriggerSettings settings, IEnumerable<Webhook> webhooks) : base(id, settings, webhooks)
    {
    }
}
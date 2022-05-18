using System;
using System.Collections.Generic;
using WD.Botifier.SharedKernel.Webhooks;

namespace WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.NewPostInSubreddit;

public class NewPostInSubredditTrigger : RedditTriggerBase<NewPostInSubredditTriggerSettings>
{
    public static NewPostInSubredditTrigger NewNewPostInSubredditTrigger(RedditTriggerName name, NewPostInSubredditTriggerSettings settings)
        => new(RedditTriggerId.NewRedditTriggerId(), name, settings, new List<Webhook>());
    
    public NewPostInSubredditTrigger(RedditTriggerId id, RedditTriggerName name, NewPostInSubredditTriggerSettings settings, IEnumerable<Webhook> webhooks) : base(id, name, settings, webhooks)
    {
    }
}
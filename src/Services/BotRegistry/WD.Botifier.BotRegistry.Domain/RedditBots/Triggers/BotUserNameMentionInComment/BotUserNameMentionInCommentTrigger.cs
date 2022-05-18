using System;
using System.Collections.Generic;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.NewPostInSubreddit;
using WD.Botifier.SharedKernel.Webhooks;

namespace WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.BotUserNameMentionInComment;

public class BotUserNameMentionInCommentTrigger : RedditTriggerBase<BotUserNameMentionInCommentTriggerSettings>
{
    public static BotUserNameMentionInCommentTrigger NewBotUserNameMentionInCommentTrigger(RedditTriggerName name, BotUserNameMentionInCommentTriggerSettings settings)
        => new(RedditTriggerId.NewRedditTriggerId(), name, settings, new List<Webhook>());
    
    public BotUserNameMentionInCommentTrigger(RedditTriggerId id, RedditTriggerName name, BotUserNameMentionInCommentTriggerSettings settings, IEnumerable<Webhook> webhooks) : base(id, name, settings, webhooks)
    {
    }
}
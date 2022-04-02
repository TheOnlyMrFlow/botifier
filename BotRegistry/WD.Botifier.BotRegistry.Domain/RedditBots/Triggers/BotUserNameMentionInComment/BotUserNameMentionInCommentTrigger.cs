using System;
using System.Collections.Generic;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.NewPostInSubreddit;
using WD.Botifier.BotRegistry.Domain.RedditBots.Webhooks;

namespace WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.BotUserNameMentionInComment;

public class BotUserNameMentionInCommentTrigger : RedditTriggerBase<BotUserNameMentionInCommentTriggerSettings>
{
    public static BotUserNameMentionInCommentTrigger NewBotUserNameMentionInCommentTrigger(BotUserNameMentionInCommentTriggerSettings settings)
        => new(RedditTriggerId.NewRedditTriggerId(), settings, new List<Webhook>());
    
    public BotUserNameMentionInCommentTrigger(RedditTriggerId id, BotUserNameMentionInCommentTriggerSettings settings, ICollection<Webhook> webhooks) : base(id, settings, webhooks)
    {
    }
}
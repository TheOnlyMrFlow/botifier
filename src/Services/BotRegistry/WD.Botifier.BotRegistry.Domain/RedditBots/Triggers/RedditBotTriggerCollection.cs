using System;
using System.Collections.Generic;
using System.Linq;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.BotUserNameMentionInComment;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.NewPostInSubreddit;
using WD.Botifier.SharedKernel.Webhooks;

namespace WD.Botifier.BotRegistry.Domain.RedditBots.Triggers;

public class RedditBotTriggerCollection
{
    private Dictionary<Guid, IRedditTrigger> _triggersById = new (); 

    public static RedditBotTriggerCollection NewRedditBotTriggerCollection()
        => new (new List<BotUserNameMentionInCommentTrigger>(), new List<NewPostInSubredditTrigger>());

    public RedditBotTriggerCollection(IEnumerable<BotUserNameMentionInCommentTrigger> botUserNameMentionInCommentTriggers, IEnumerable<NewPostInSubredditTrigger> newPostInSubredditTriggers)
    {
        _botUserNameMentionInCommentTriggers = new List<BotUserNameMentionInCommentTrigger>(botUserNameMentionInCommentTriggers);
        _newPostInSubredditTriggers = new  List<NewPostInSubredditTrigger>(newPostInSubredditTriggers);

        foreach (var trigger in _botUserNameMentionInCommentTriggers.Concat<IRedditTrigger>(_newPostInSubredditTriggers))
            _triggersById.Add(trigger.Id.Value, trigger);
    }
    
    private readonly ICollection<BotUserNameMentionInCommentTrigger> _botUserNameMentionInCommentTriggers;
    public IReadOnlyCollection<BotUserNameMentionInCommentTrigger> BotUserNameMentionInCommentTriggers => _botUserNameMentionInCommentTriggers.ToList().AsReadOnly();
    
    private readonly ICollection<NewPostInSubredditTrigger> _newPostInSubredditTriggers;
    public IReadOnlyCollection<NewPostInSubredditTrigger> NewPostInSubredditTriggers => _newPostInSubredditTriggers.ToList().AsReadOnly();
    
    private void AddTriggerToDictionary(IRedditTrigger trigger) => _triggersById.Add(trigger.Id.Value, trigger);

    public void AddTrigger(BotUserNameMentionInCommentTrigger trigger)
    {
        _botUserNameMentionInCommentTriggers.Add(trigger);
        AddTriggerToDictionary(trigger);
    }
    
    public void AddTrigger(NewPostInSubredditTrigger trigger)
    {
        _newPostInSubredditTriggers.Add(trigger);
        AddTriggerToDictionary(trigger);
    }
    
    public void AddWebhookToTrigger(RedditTriggerId triggerId, Webhook webhook)
    {
        var trigger = _triggersById[triggerId.Value]; // todo error handling if not exists
        trigger.AddWebhook(webhook);
    }
    
    public RedditBotTriggerReadonlyCollection AsReadonly() 
        => new (BotUserNameMentionInCommentTriggers, NewPostInSubredditTriggers);
}

public class RedditBotTriggerReadonlyCollection
{
    public RedditBotTriggerReadonlyCollection(IReadOnlyCollection<BotUserNameMentionInCommentTrigger> botUserNameMentionInCommentTrigger, IReadOnlyCollection<NewPostInSubredditTrigger> newPostInSubredditTrigger)
    {
        BotUserNameMentionInCommentTrigger = botUserNameMentionInCommentTrigger;
        NewPostInSubredditTrigger = newPostInSubredditTrigger;
    }

    public IReadOnlyCollection<BotUserNameMentionInCommentTrigger> BotUserNameMentionInCommentTrigger;
    public IReadOnlyCollection<NewPostInSubredditTrigger> NewPostInSubredditTrigger;
}
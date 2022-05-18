using System;
using System.Collections.Generic;
using System.Linq;
using OneOf;
using OneOf.Types;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.BotUserNameMentionInComment;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.NewPostInSubreddit;
using WD.Botifier.SeedWork;
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
    
    public void RemoveTrigger(RedditTriggerId triggerId)
    {
        if (!_triggersById.TryGetValue(triggerId.Value, out var triggerToRemove))
            return;

        switch (triggerToRemove)
        {
            case NewPostInSubredditTrigger t:
                _newPostInSubredditTriggers.Remove(t);
                break;
            case BotUserNameMentionInCommentTrigger t:
                _botUserNameMentionInCommentTriggers.Remove(t);
                break;
            default: throw new NotImplementedException();
        }

        _triggersById.Remove(triggerId.Value);
    }

    public void AddWebhookToTrigger(RedditTriggerId triggerId, Webhook webhook)
    {
        if (!_triggersById.TryGetValue(triggerId.Value, out var trigger))
            throw new TriggerDoesNotExistException();

        trigger.AddWebhook(webhook);
    }
    
    public void RemoveWebhookFromTrigger(RedditTriggerId triggerId, WebhookName webhookName)
    {
        if (!_triggersById.TryGetValue(triggerId.Value, out var trigger))
            throw new TriggerDoesNotExistException();

        trigger.RemoveWebhook(webhookName);
    }
    
    public RedditBotTriggerReadonlyCollection AsReadonly() 
        => new (BotUserNameMentionInCommentTriggers, NewPostInSubredditTriggers);
}

public class RedditBotTriggerReadonlyCollection
{
    public RedditBotTriggerReadonlyCollection(IReadOnlyCollection<BotUserNameMentionInCommentTrigger> botUserNameMentionInCommentTriggers, IReadOnlyCollection<NewPostInSubredditTrigger> newPostInSubredditTriggers)
    {
        BotUserNameMentionInCommentTriggers = botUserNameMentionInCommentTriggers;
        NewPostInSubredditTriggers = newPostInSubredditTriggers;
    }

    public readonly IReadOnlyCollection<BotUserNameMentionInCommentTrigger> BotUserNameMentionInCommentTriggers;
    public readonly IReadOnlyCollection<NewPostInSubredditTrigger> NewPostInSubredditTriggers;
}
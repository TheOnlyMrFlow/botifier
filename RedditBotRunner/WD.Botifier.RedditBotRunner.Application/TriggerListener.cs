using System;
using System.Collections.Generic;
using WD.Botifier.RedditBotRunner.Application.Ports;
using WD.Botifier.RedditBotRunner.Domain.Triggers;
using WD.Botifier.SeedWork;

namespace WD.Botifier.RedditBotRunner.Application;

public class TriggerListener
{
    private readonly Dictionary<Guid, IDisposable> _unsubscribers = new ();

    private readonly INewPostInSubredditWatcher _newPostInSubredditWatcher;

    public TriggerListener(INewPostInSubredditWatcher newPostInSubredditWatcher)
    {
        _newPostInSubredditWatcher = newPostInSubredditWatcher;
    }

    public void AddNewPostInSubredditTrigger(NewPostInSubredditTrigger trigger)
    {
        var observer = new NewPostInSubredditObserver(trigger);
        _unsubscribers.Add(trigger.Id, _newPostInSubredditWatcher.Subscribe(observer));
    }

    public void RemoveTrigger(Guid triggerId)
    {
        _unsubscribers[triggerId].Dispose();
    }
}

public class NewPostInSubredditObserver : IObserver<NewPostInSubredditEvent>
{
    private NewPostInSubredditTrigger _trigger;
    private IRedditWriter _redditWriter;
    private IDomainEventEmitter _eventEmitter;

    public NewPostInSubredditObserver(NewPostInSubredditTrigger trigger, IRedditWriter redditWriter, IDomainEventEmitter eventEmitter)
    {
        _trigger = trigger;
        _redditWriter = redditWriter;
        _eventEmitter = eventEmitter;
    }

    public void OnCompleted()
    {
        
    }

    public void OnError(Exception error)
    {
       
    }

    public void OnNext(NewPostInSubredditEvent @event)
    {
        _eventEmitter.Emit(@event);
    }
}
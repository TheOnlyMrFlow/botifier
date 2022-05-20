using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Reddit;
using Reddit.Controllers.EventArgs;
using WD.Botifier.SharedKernel.Reddit;
using WD.Botifier.SharedKernel.Reddit.Posts;

namespace WD.Botifier.RedditBotRunner.Infra.RedditWatcher.RedditDotNet.RedditWatchers;

internal class NewPostInSubredditWatcher
{
    private readonly RedditClient _redditClient;
    private readonly Dictionary<SubredditName, ICollection<WatchSubscription>> _subscriptions = new ();
    private readonly Dictionary<SubredditName, IDisposable> _subredditObservers = new ();

    public NewPostInSubredditWatcher(RedditClient redditClient)
    {
        _redditClient = redditClient;
        //_redditSharpClient = new RedditSharpClient(new BotWebAgent("8bitfier", "fPrL^N%S3Lc02NC%", "UXyHK6OWWmkULQ", "WWXpXdd6LqaQ4de72ArpvLdoJEORLQ", "https://google.com"), true);
    }

    public IDisposable Watch(IEnumerable<SubredditName> subreddits, Action<RedditPost> callback)
    {
        foreach (var subreddit in subreddits)
            ObserveSubredditIfNotAlready(subreddit);

        var watchSubscription = new WatchSubscription(subreddits, callback);
        foreach (var subreddit in watchSubscription.Subreddits)
        {
            if (!_subscriptions.ContainsKey(subreddit))
                _subscriptions.Add(subreddit, new List<WatchSubscription>());
            
            _subscriptions[subreddit].Add(watchSubscription);
        }
        
        return Disposable.Create(() => DisposeSubscription(watchSubscription));
    }

    private void ObserveSubredditIfNotAlready(SubredditName subredditName)
    {
        if (_subredditObservers.ContainsKey(subredditName))
            return;

        var subreddit = _redditClient.Subreddit(subredditName.WithRSlash);
        subreddit.Posts.NewUpdated += SubredditPostsFetchedEventHandler;
        subreddit.Posts.MonitorNew();

        var observer = Disposable.Create(() => subreddit.Posts.KillAllMonitoringThreads());
        _subredditObservers.Add(subredditName, observer);
    }

    private void DisposeSubscription(WatchSubscription subscription)
    {
        foreach (var subreddit in subscription.Subreddits)
        {
            _subscriptions[subreddit].Remove(subscription);

            if (_subscriptions[subreddit].Count == 0)
                OnSubredditNoLongerBeingWatched(subreddit);
        }
    }

    private void OnSubredditNoLongerBeingWatched(SubredditName subreddit)
    {
        _subscriptions.Remove(subreddit);
        _subredditObservers[subreddit].Dispose();
    }
    
    private void SubredditPostsFetchedEventHandler(object? sender, PostsUpdateEventArgs e)
    {
        foreach (var newPost in e.Added) 
            OnNewPost(newPost.Listing.ToDomainRedditPost());
    }

    private void OnNewPost(RedditPost post)
    {
        foreach (var subscription in _subscriptions[post.Subreddit]) 
            subscription.Callback(post);
    }

    private class WatchSubscription
    {
        public Action<RedditPost> Callback { get; }
        public IReadOnlyCollection<SubredditName> Subreddits { get; set; }

        public WatchSubscription(IEnumerable<SubredditName> subreddits, Action<RedditPost> callback)
        {
            Callback = callback;
            Subreddits = new List<SubredditName>(subreddits).AsReadOnly();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Threading;
using RedditSharp;
using WD.Botifier.RedditBotRunner.Infra.RedditApIClient;
using WD.Botifier.SharedKernel.Reddit;
using WD.Botifier.SharedKernel.Reddit.Posts;

namespace WD.Botifier.RedditBotRunner.Infra.RedditApiClient.RedditWatcher;

internal class NewPostInSubredditWatcher
{
    private readonly RedditSharpClient _redditSharpClient;
    private readonly Dictionary<SubredditName, ICollection<WatchSubscription>> _subscriptions = new ();
    private readonly Dictionary<SubredditName, CancellationTokenSource> _enumeratorsCancellationTokenSources = new ();
    private readonly Dictionary<SubredditName, IDisposable> _subredditObservers = new ();

    public NewPostInSubredditWatcher(RedditSharpClient redditSharpClient)
    {
        _redditSharpClient = redditSharpClient;
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

    private void ObserveSubredditIfNotAlready(SubredditName subreddit)
    {
        if (_subredditObservers.ContainsKey(subreddit))
            return;

        var postStream = _redditSharpClient
            .GetSubredditAsync(subreddit.WithoutRSlash)
            .GetAwaiter()
            .GetResult()
            .GetPosts()
            .Stream();
            
        var observer = postStream.Subscribe(redditSharpPost => OnNewPost(redditSharpPost.ToDomainRedditPost()));
        _subredditObservers.Add(subreddit, observer);

        var enumeratorCancellationTokenSource = new CancellationTokenSource();
        postStream.Enumerate(enumeratorCancellationTokenSource.Token);
        _enumeratorsCancellationTokenSources.Add(subreddit, enumeratorCancellationTokenSource);
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
        _enumeratorsCancellationTokenSources[subreddit].Cancel();
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
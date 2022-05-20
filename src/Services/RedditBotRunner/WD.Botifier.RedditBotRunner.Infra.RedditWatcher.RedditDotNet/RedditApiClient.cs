using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reddit;
using WD.Botifier.RedditBotRunner.Application.Ports;
using WD.Botifier.RedditBotRunner.Domain.Bots;
using WD.Botifier.RedditBotRunner.Domain.Intents;
using WD.Botifier.RedditBotRunner.Infra.RedditWatcher.RedditDotNet.RedditWatchers;
using WD.Botifier.SharedKernel.Reddit;
using WD.Botifier.SharedKernel.Reddit.Comments;
using WD.Botifier.SharedKernel.Reddit.Posts;

namespace WD.Botifier.RedditBotRunner.Infra.RedditWatcher.RedditDotNet;

public class RedditApiClient : IAuthfulRedditApi, IAuthlessRedditApi
{
    private readonly RedditClient _redditClient;
    private readonly NewPostInSubredditWatcher _newPostInSubredditWatcher;
    private readonly UserNameMentionWatcher _userNameMentionWatcher;
    private readonly ICollection<IDisposable> _subscriptions = new List<IDisposable>();

    public RedditApiClient(RedditClient redditClient)
    {
        _redditClient = redditClient;
        _userNameMentionWatcher = new UserNameMentionWatcher(_redditClient);
        _newPostInSubredditWatcher = new NewPostInSubredditWatcher(_redditClient);
        //var toto = _redditClient.SearchSubreddits("test").Last();
    }
    
    public RedditApiClient(RedditRefreshToken refreshToken) : this(new RedditClient("ZLhJZeJQPg3WFoQs80iAHA", refreshToken.Value))
    {
    }

    public IDisposable WatchUserNameMentions(Action<RedditComment> callback)
    {
        var subscription = _userNameMentionWatcher.Watch(callback);
        _subscriptions.Add(subscription);
        return subscription;
    }
    
    public IDisposable WatchNewPostsInSubreddit(IEnumerable<SubredditName> subreddits, Action<RedditPost> callback)
    {
        var subscription = _newPostInSubredditWatcher.Watch(subreddits, callback);
        _subscriptions.Add(subscription);
        return subscription;
    }

    public Task<object> ReplyToCommentAsync(ReplyToCommentIntent intent)
    {
        throw new System.NotImplementedException();
    }

    public Task<object> ReplyToPostAsync(ReplyToPostIntent intent)
    {
        throw new System.NotImplementedException();
    }

    public void Dispose()
    {
        foreach (var subscription in _subscriptions)
            subscription.Dispose();
    }
}



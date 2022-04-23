using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using RedditSharp;
using WD.Botifier.RedditBotRunner.Application.Ports;
using WD.Botifier.RedditBotRunner.Domain.Intents;
using WD.Botifier.RedditBotRunner.Infra.RedditApiClient.RedditWatcher;
using WD.Botifier.SharedKernel.Reddit;
using WD.Botifier.SharedKernel.Reddit.AppCredentials;
using WD.Botifier.SharedKernel.Reddit.Comments;
using WD.Botifier.SharedKernel.Reddit.Posts;

namespace WD.Botifier.RedditBotRunner.Infra.RedditApIClient;

public class RedditApiClient : IAuthfulRedditApi, IAuthlessRedditApi
{
    private readonly RedditSharpClient _redditSharpClient;
    private readonly NewPostInSubredditWatcher _newPostInSubredditWatcher;
    private readonly UserNameMentionWatcher _userNameMentionWatcher;
    private readonly ICollection<IDisposable> _subscriptions = new List<IDisposable>();

    public RedditApiClient(RedditSharpClient redditSharpClient)
    {
        _redditSharpClient = redditSharpClient;
        _userNameMentionWatcher = new UserNameMentionWatcher(_redditSharpClient);
        _newPostInSubredditWatcher = new NewPostInSubredditWatcher(_redditSharpClient);
    }
    
    public RedditApiClient(RedditAppCredentials credentials) : this(new RedditSharpClient(new BotWebAgent(credentials.UserName.WithoutUSlash, credentials.Password.Value, credentials.AppClientId.Value, credentials.AppClientSecret.Value, credentials.RedirectUri.ToString()), true))
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



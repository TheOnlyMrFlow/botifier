using System;
using System.Collections.Generic;
using WD.Botifier.RedditBotRunner.Application.Ports;
using WD.Botifier.SharedKernel.Reddit;
using WD.Botifier.SharedKernel.Reddit.AppCredentials;
using WD.Botifier.SharedKernel.Reddit.Comments;
using WD.Botifier.SharedKernel.Reddit.Posts;

namespace WD.Botifier.RedditBotRunner.Infra.RedditApiClient.RedditWatcher;

public class RedditWatcher : IRedditWatcher
{
    private readonly NewPostInSubredditWatcher _newPostInSubredditWatcher;
    private readonly UserNameMentionWatcher _userNameMentionWatcher;

    public RedditWatcher()
    {
        _userNameMentionWatcher = new UserNameMentionWatcher();
        _newPostInSubredditWatcher = new NewPostInSubredditWatcher();
    }

    public IDisposable WatchNewPostsInSubreddit(IEnumerable<SubredditName> subreddits, Action<RedditPost> callback)
        => _newPostInSubredditWatcher.Watch(subreddits, callback);

    public IDisposable WatchUserNameMentions(RedditAppCredentials appCredentials, Action<RedditComment> callback)
        => _userNameMentionWatcher.Watch(appCredentials, callback);
}
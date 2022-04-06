using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WD.Botifier.RedditBotRunner.Domain.Intents;
using WD.Botifier.SharedKernel.Reddit;
using WD.Botifier.SharedKernel.Reddit.AppCredentials;
using WD.Botifier.SharedKernel.Reddit.Comments;
using WD.Botifier.SharedKernel.Reddit.Posts;

namespace WD.Botifier.RedditBotRunner.Application.Ports;

public interface IRedditWriter
{
    Task<object> ReplyToCommentAsync(ReplyToCommentIntent intent);
    Task<object> ReplyToPostAsync(ReplyToPostIntent intent);
}

public interface IRedditWatcher
{
    IDisposable WatchNewPostsInSubreddit(IEnumerable<SubredditName> subreddits, Action<RedditPost> callback);

    IDisposable WatchUserNameMentions(RedditAppCredentials appCredentials, Action<RedditComment> callback);
}
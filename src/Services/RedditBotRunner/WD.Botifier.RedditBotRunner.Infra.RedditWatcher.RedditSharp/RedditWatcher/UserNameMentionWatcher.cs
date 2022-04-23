using System;
using System.Reactive.Disposables;
using System.Threading;
using RedditSharp;
using WD.Botifier.RedditBotRunner.Infra.RedditApIClient;
using WD.Botifier.SharedKernel.Reddit.Comments;

namespace WD.Botifier.RedditBotRunner.Infra.RedditApiClient.RedditWatcher;

internal class UserNameMentionWatcher
{
    private readonly RedditSharpClient _redditSharpClient;

    public UserNameMentionWatcher(Reddit redditSharpClient)
    {
        _redditSharpClient = redditSharpClient;
    }

    public IDisposable Watch(Action<RedditComment> callback)
    {
        var mentionStream = _redditSharpClient.User
            .GetUsernameMentions()
            .Stream();
            
        mentionStream.Subscribe(redditSharpComment => callback(redditSharpComment.ToDomainRedditComment()));
        
        var cancellationTokenSource = new CancellationTokenSource();
        mentionStream.Enumerate(cancellationTokenSource.Token);
        
        return Disposable.Create(() => cancellationTokenSource.Cancel());
    }
}
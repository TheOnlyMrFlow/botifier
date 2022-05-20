using System;
using System.Linq;
using System.Reactive.Disposables;
using Reddit;
using Reddit.Controllers.EventArgs;
using WD.Botifier.SharedKernel.Reddit.Comments;

namespace WD.Botifier.RedditBotRunner.Infra.RedditWatcher.RedditDotNet.RedditWatchers;

internal class UserNameMentionWatcher
{
    private readonly RedditClient _redditClient;
    private Action<RedditComment> _callback = _ => { };

    public UserNameMentionWatcher(RedditClient redditClient)
    {
        _redditClient = redditClient;
    }

    public IDisposable Watch(Action<RedditComment> callback)
    {
        _redditClient.Account.Messages.UnreadUpdated -= NewUnreadMessageEventHandler;
        _redditClient.Account.Messages.UnreadUpdated += NewUnreadMessageEventHandler;
        _redditClient.Account.Messages.MonitorUnread();

        return Disposable.Create(() => _redditClient.Account.Messages.KillAllMonitoringThreads());
    }
    
    private void NewUnreadMessageEventHandler(object? sender, MessagesUpdateEventArgs e)
    {
        foreach (var message in e.Added.Where(m => m.Subject.ToLower() == "username mention"))
        {
            var comment = _redditClient.Comment(message.ParentId).Listing;
            _callback(comment!.ToDomainRedditComment());
        }
    }
}
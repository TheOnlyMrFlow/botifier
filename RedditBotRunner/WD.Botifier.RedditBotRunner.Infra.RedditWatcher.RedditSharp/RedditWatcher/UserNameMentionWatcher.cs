using System;
using RedditSharp;
using WD.Botifier.SharedKernel.Reddit.AppCredentials;
using WD.Botifier.SharedKernel.Reddit.Comments;

namespace WD.Botifier.RedditBotRunner.Infra.RedditApiClient.RedditWatcher;

internal class UserNameMentionWatcher
{
    public IDisposable Watch(RedditAppCredentials credentials, Action<RedditComment> callback)
    {
        return new RedditSharpClient(new BotWebAgent(credentials.UserName.Value, credentials.Password.Value, credentials.AppClientId.Value, credentials.AppClientSecret.Value, "google.fr"), true)
            .User
            .GetUsernameMentions()
            .Stream()
            .Subscribe(redditSharpComment => callback(RedditComment.FromRawJson(redditSharpComment.RawJson.ToString())));
    }
}
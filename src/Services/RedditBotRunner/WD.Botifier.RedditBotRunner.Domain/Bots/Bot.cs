using WD.Botifier.RedditBotRunner.Domain.Bots.Triggers.NewPostInSubredit;
using WD.Botifier.RedditBotRunner.Domain.Bots.Triggers.UserNameMentionInComment;
using WD.Botifier.SharedKernel.Reddit.AppCredentials;

namespace WD.Botifier.RedditBotRunner.Domain.Bots;

public class Bot
{
    public Bot(Guid botId, RedditRefreshToken refreshToken, IEnumerable<NewPostInSubredditTrigger> newPostInSubredditTriggers, IEnumerable<UserNameMentionInCommentTrigger> userNameMentionInCommentTriggers)
    {
        BotId = botId;
        RefreshToken = refreshToken;
        NewPostInSubredditTriggers = newPostInSubredditTriggers;
        UserNameMentionInCommentTriggers = userNameMentionInCommentTriggers;
    }

    public Guid BotId { get; }

    public RedditRefreshToken RefreshToken { get; } // todo
    
    public IEnumerable<NewPostInSubredditTrigger> NewPostInSubredditTriggers { get; }
    
    public IEnumerable<UserNameMentionInCommentTrigger> UserNameMentionInCommentTriggers { get; }
}
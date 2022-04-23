using WD.Botifier.RedditBotRunner.Domain.Triggers;
using WD.Botifier.RedditBotRunner.Domain.Triggers.NewPostInSubredit;
using WD.Botifier.RedditBotRunner.Domain.Triggers.UserNameMentionInComment;
using WD.Botifier.SharedKernel.Reddit.AppCredentials;

namespace WD.Botifier.RedditBotRunner.Domain;

public class Bot
{
    public Bot(Guid botId, RedditAppCredentials credentials, IEnumerable<NewPostInSubredditTrigger> newPostInSubredditTriggers, IEnumerable<UserNameMentionInCommentTrigger> userNameMentionInCommentTriggers)
    {
        BotId = botId;
        Credentials = credentials;
        NewPostInSubredditTriggers = newPostInSubredditTriggers;
        UserNameMentionInCommentTriggers = userNameMentionInCommentTriggers;
    }

    public Guid BotId { get; }
    
    public RedditAppCredentials Credentials { get; }
    
    public IEnumerable<NewPostInSubredditTrigger> NewPostInSubredditTriggers { get; }
    
    public IEnumerable<UserNameMentionInCommentTrigger> UserNameMentionInCommentTriggers { get; }
}
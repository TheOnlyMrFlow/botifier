using WD.Botifier.SeedWork;

namespace WD.Botifier.BotRegistry.Domain.RedditBots.Triggers;

public class RedditTriggerType : Enumeration
{
    public static RedditTriggerType BotUserNameMentionInComment = new(nameof(BotUserNameMentionInComment));
    public static RedditTriggerType NewPostInSubreddit = new(nameof(BotUserNameMentionInComment));
    
    protected RedditTriggerType(string name) : base(name)
    {
    }
}
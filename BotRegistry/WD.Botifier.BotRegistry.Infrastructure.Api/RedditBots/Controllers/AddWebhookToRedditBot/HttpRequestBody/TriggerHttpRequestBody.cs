namespace WD.Botifier.BotRegistry.Infrastructure.Api.RedditBots.Controllers.AddWebhookToRedditBot.HttpRequestBody;


public interface ITriggerHttpRequestBody
{
    public const string BotUsernameMentionInCommentTriggerType = "BotUsernameMentionInComment";
    public const string NewPostInSubredditTriggerType = "NewPostInSubreddit";
    
    string TriggerType { get; set; }
}


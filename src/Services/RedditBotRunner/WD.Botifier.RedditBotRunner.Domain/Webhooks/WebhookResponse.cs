using WD.Botifier.RedditBotRunner.Domain.Intents;

namespace WD.Botifier.RedditBotRunner.Domain.Webhooks;

public class WebhookResponse
{
    public WebhookResponse(IEnumerable<ReplyToCommentIntent> replyToCommentIntents, IEnumerable<ReplyToPostIntent> replyToPostIntents)
    {
        ReplyToCommentIntents = replyToCommentIntents;
        ReplyToPostIntents = replyToPostIntents;
    }
    
    public IEnumerable<ReplyToCommentIntent> ReplyToCommentIntents { get; }
    
    public IEnumerable<ReplyToPostIntent> ReplyToPostIntents { get; }
}
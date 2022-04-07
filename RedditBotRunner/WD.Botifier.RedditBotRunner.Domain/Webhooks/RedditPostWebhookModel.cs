using WD.Botifier.SharedKernel.Reddit.Posts;

namespace WD.Botifier.RedditBotRunner.Domain.Webhooks;

public class RedditPostWebhookModel
{
    public RedditPostWebhookModel(RedditPost post)
    {
        Content = post.Content.Value;
    }

    public string Content { get; }
}
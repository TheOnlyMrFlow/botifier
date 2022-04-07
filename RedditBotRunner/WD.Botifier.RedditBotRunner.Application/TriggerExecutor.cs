using System.Threading.Tasks;
using WD.Botifier.RedditBotRunner.Domain.Triggers;
using WD.Botifier.RedditBotRunner.Domain.Webhooks;
using WD.Botifier.SharedKernel.Reddit.Posts;

namespace WD.Botifier.RedditBotRunner.Application;

public class TriggerExecutor
{
    private readonly WebhookCaller _webhookCaller;

    public TriggerExecutor(WebhookCaller webhookCaller)
    {
        _webhookCaller = webhookCaller;
    }

    public async Task ExecuteAsync(NewPostInSubredditTriggerMatch newPostInSubredditTriggerMatch)
    {
        foreach (var webhook in newPostInSubredditTriggerMatch.Trigger.Webhooks)
        {
            var webhookRequest = new object();
            await _webhookCaller.CallWebhookAsync(webhook, new NewPostInSubredditWebhookPayload(newPostInSubredditTriggerMatch));
        }
    }
}
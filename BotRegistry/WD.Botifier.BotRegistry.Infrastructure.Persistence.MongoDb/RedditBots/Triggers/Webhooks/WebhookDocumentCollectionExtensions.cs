using System.Collections.Generic;
using System.Linq;
using WD.Botifier.BotRegistry.Domain.RedditBots.Webhooks;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots.Triggers.Webhooks;

public static class WebhookDocumentCollectionExtensions
{
    public static IEnumerable<Webhook> ToWebhooks(this IEnumerable<WebhookDocument>? webhookDocuments)
        => webhookDocuments?.Select(wh => wh.ToWebhook()) ?? Enumerable.Empty<Webhook>();
}
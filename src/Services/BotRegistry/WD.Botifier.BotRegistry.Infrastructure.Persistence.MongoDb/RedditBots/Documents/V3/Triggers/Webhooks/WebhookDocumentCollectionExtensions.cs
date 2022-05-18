using System.Collections.Generic;
using System.Linq;
using WD.Botifier.SharedKernel.Webhooks;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots.Document.V3.Triggers.Webhooks;

public static class WebhookDocumentCollectionExtensions
{
    public static IEnumerable<Webhook> ToWebhooks(this IEnumerable<WebhookDocument>? webhookDocuments)
        => webhookDocuments?.Select(wh => wh.ToWebhook()) ?? Enumerable.Empty<Webhook>();
}
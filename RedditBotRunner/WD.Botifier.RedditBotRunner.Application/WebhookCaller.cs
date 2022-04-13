using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using WD.Botifier.RedditBotRunner.Domain.Intents;
using WD.Botifier.RedditBotRunner.Domain.Webhooks;
using WD.Botifier.SharedKernel.Webhooks;

namespace WD.Botifier.RedditBotRunner.Application;

public class WebhookCaller
{
    public async Task<WebhookResponse> CallWebhookAsync<T>(Webhook webhook, T payload) where T : IWebhookPayload
    {
        using var restClient = new RestClient();
        var request = new RestRequest(webhook.Url, Method.Post);
        request.AddHeader("cache-control", "no-cache");
        request.AddHeader("content-type", "application/json");
        request.AddBody(payload);
        var response = await restClient.ExecuteAsync(request);
        
        return JsonConvert.DeserializeObject<WebhookResponse>(response.Content ?? "") ?? new WebhookResponse(Array.Empty<ReplyToCommentIntent>(), Array.Empty<ReplyToPostIntent>());
    }
}
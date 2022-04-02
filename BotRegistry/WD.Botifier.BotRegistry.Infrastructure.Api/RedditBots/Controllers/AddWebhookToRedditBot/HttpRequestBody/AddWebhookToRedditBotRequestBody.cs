namespace WD.Botifier.BotRegistry.Infrastructure.Api.RedditBots.Controllers.AddWebhookToRedditBot;

public class AddWebhookToRedditBotRequestBody<TTriggerHttpRequestBody>
{
    public string WebhookName { get; set; }
    
    public string WebhookUrl { get; set; }
    
    public TTriggerHttpRequestBody Trigger { get; set; }
}
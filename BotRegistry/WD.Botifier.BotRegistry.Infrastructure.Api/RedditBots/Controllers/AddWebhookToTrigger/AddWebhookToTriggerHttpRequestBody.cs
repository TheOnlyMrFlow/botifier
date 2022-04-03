using System.ComponentModel.DataAnnotations;

namespace WD.Botifier.BotRegistry.Infrastructure.Api.RedditBots.Controllers.AddWebhookToTrigger;

public class AddWebhookToTriggerHttpRequestBody
{
    [Required]
    public string WebhookName { get; set; }
    
    [Required]
    public string WebhookUrl { get; set; }
}
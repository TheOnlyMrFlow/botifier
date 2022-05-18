using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WD.Botifier.BotRegistry.Application.RedditBots.RemoveWebhookFromTrigger;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers;
using WD.Botifier.SharedKernel.Webhooks;

namespace WD.Botifier.BotRegistry.Infrastructure.Api.RedditBots.Controllers.RemoveWebhookFromTrigger;

[ApiController]
public class RemoveWebhookFromTriggerController : ControllerBase
{
    private readonly ILogger<RemoveWebhookFromTriggerController> _logger;
    private readonly RemoveWebhookFromTriggerCommandHandler _removeWebhookFromTriggerCommandHandler;

    public RemoveWebhookFromTriggerController(ILogger<RemoveWebhookFromTriggerController> logger, RemoveWebhookFromTriggerCommandHandler removeWebhookFromTriggerCommandHandler)
    {
        _logger = logger;
        _removeWebhookFromTriggerCommandHandler = removeWebhookFromTriggerCommandHandler;
    }
    
    [Authorize]
    [HttpDelete("redditBots/{botId:guid}/triggers/{triggerId:guid}/webhooks/{webhookName}", Name = "Remove a webhook from the trigger of a bot")]
    public async Task<IActionResult?> AddWebhookToTriggerAsync(Guid botId, Guid triggerId, string webhookName)
    {
        var userId = this.GetAuthenticatedUserId();
        var command = new RemoveWebhookFromTriggerCommand(userId, new RedditBotId(botId), new RedditTriggerId(triggerId), new WebhookName(WebUtility.UrlDecode(webhookName)));

        var result = await _removeWebhookFromTriggerCommandHandler.HandleAsync(command);

        return result.Match<IActionResult>(
            success => NoContent(),
            botNotFoundError => NotFound(new ProblemDetails { Title = "Not found.", Detail = "Bot was not found."}),
            triggerNotFound =>  NotFound(new ProblemDetails { Title = "Not found.", Detail = "Trigger was not found."})
        );
    }
}
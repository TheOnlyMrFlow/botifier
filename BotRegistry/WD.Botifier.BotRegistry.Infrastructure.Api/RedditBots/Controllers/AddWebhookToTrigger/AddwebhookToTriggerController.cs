using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WD.Botifier.BotRegistry.Application.RedditBots.AddNewPostInSubredditTrigger;
using WD.Botifier.BotRegistry.Application.RedditBots.AddWebhookToTrigger;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers;
using WD.Botifier.BotRegistry.Infrastructure.Api.RedditBots.Controllers.AddBotUserNameMentionInCommentTrigger;
using WD.Botifier.BotRegistry.Infrastructure.Api.RedditBots.Controllers.AddNewPostInSubredditTrigger;
using WD.Botifier.SharedKernel.Reddit;
using WD.Botifier.SharedKernel.Webhooks;

namespace WD.Botifier.BotRegistry.Infrastructure.Api.RedditBots.Controllers.AddWebhookToTrigger;

[ApiController]
public class AddwebhookToTriggerController : ControllerBase
{
    private readonly ILogger<AddBotUserNameMentionInCommentTriggerController> _logger;
    private readonly AddWebhookToTriggerCommandHandler _addWebhookToTriggerCommandHandler;

    public AddwebhookToTriggerController(ILogger<AddBotUserNameMentionInCommentTriggerController> logger, AddWebhookToTriggerCommandHandler addWebhookToTriggerCommandHandler)
    {
        _logger = logger;
        _addWebhookToTriggerCommandHandler = addWebhookToTriggerCommandHandler;
    }
    
    [Authorize]
    [HttpPost("redditBots/{botId:guid}/triggers/{triggerId:guid}/webhooks", Name = "Add a webhook to the trigger of a bot")]
    public async Task<IActionResult?> AddWebhookToTriggerAsync(Guid botId, Guid triggerId, AddWebhookToTriggerHttpRequestBody requestBody)
    {
        var userId = this.GetAuthenticatedUserId();
        var command = new AddWebhookToTriggerCommand(userId, new RedditBotId(botId), new RedditTriggerId(triggerId), new WebhookName(requestBody.WebhookName), new Uri(requestBody.WebhookUrl));

        var result = await _addWebhookToTriggerCommandHandler.HandleAsync(command);

        return result.Match<IActionResult>(
            success => Created(string.Empty, null),
            botNotFoundError => NotFound(new ProblemDetails { Title = "Not found.", Detail = "Bot was not found."})
        );
    }
}
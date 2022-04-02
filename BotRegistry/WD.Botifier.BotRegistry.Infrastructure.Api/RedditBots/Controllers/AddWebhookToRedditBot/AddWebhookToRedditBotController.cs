using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WD.Botifier.BotRegistry.Application.RedditBots.AddBotUserNameMentionInCommentWebhook;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.SharedKernel.Webhooks;

namespace WD.Botifier.BotRegistry.Infrastructure.Api.RedditBots.Controllers.AddBotUserNameMentionInCommentWebhook;

[ApiController]
public class AddBotUserNameMentionInCommentWebhookController : ControllerBase
{
    private readonly ILogger<AddBotUserNameMentionInCommentWebhookController> _logger;
    private readonly AddBotUserNameMentionInCommentWebhookCommandHandler _commandHandler;

    public AddBotUserNameMentionInCommentWebhookController(ILogger<AddBotUserNameMentionInCommentWebhookController> logger, AddBotUserNameMentionInCommentWebhookCommandHandler commandHandler)
    {
        _logger = logger;
        _commandHandler = commandHandler;
    }

    [Authorize]
    [HttpPost("redditBots/{botId:guid}/webhooks", Name = "Add a new webhook triggered when bot username is mentioned in a comment")]
    public async Task<IActionResult?> AddBotUserNameMentionInCommentWebhookAsync(Guid botId, [FromBody] AddBotUserNameMentionInCommentWebhookHttpRequestBody requestBody)
    {
        var userId = this.GetAuthenticatedUserId();
        var command = new AddBotUserNameMentionInCommentWebhookCommand(userId, new RedditBotId(botId), new WebhookName(requestBody.WebhookName), new Uri(requestBody.WebhookUrl));

        var result = await _commandHandler.HandleAsync(command);

        return result.Match<IActionResult>(
            success => Created(string.Empty, null),
            botNotFoundError => NotFound(new ProblemDetails { Title = "Not found.", Detail = "Bot was not found."})
            );
    }
}
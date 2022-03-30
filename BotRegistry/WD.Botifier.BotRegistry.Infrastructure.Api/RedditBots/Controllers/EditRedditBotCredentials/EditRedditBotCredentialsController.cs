using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WD.Botifier.BotRegistry.Application.RedditBots.EditRedditBotCredentials;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.RedditBots.Credentials;
using WD.Botifier.BotRegistry.Infrastructure.Api.RedditBots.Controllers.CreateRedditBot;

namespace WD.Botifier.BotRegistry.Infrastructure.Api.RedditBots.Controllers.EditRedditBotCredentials;

[ApiController]
public class EditRedditBotCredentialsController : ControllerBase
{
    private readonly ILogger<CreateRedditBotController> _logger;
    private readonly EditRedditBotCredentialsCommandHandler _commandHandler;

    public EditRedditBotCredentialsController(ILogger<CreateRedditBotController> logger, EditRedditBotCredentialsCommandHandler commandHandler)
    {
        _logger = logger;
        _commandHandler = commandHandler;
    }

    [Authorize]
    [HttpPut("redditBots/{botId:guid}/credentials", Name = "Edit reddit bot credentials")]
    public async Task<IActionResult?> CreateBotAsync(Guid botId, [FromBody] EditRedditBotCredentialsHttpRequestBody requestBody)
    {
        var userId = this.GetAuthenticatedUserId();
        var command = new EditRedditBotCredentialsCommand(
            userId,
            new RedditBotId(botId),
            new RedditUserName(requestBody.Username),
            new RedditPassword(requestBody.Password),
            new RedditClientId(requestBody.ClientId),
            new RedditClientSecret(requestBody.ClientSecret));

        var result = await _commandHandler.HandleAsync(command);

        return result.Match<IActionResult>(
            success => Ok(),
            botNotFound => NotFound(new ProblemDetails { Title = "NotFound.", Detail = "Bot not found."})
            );
    }
}
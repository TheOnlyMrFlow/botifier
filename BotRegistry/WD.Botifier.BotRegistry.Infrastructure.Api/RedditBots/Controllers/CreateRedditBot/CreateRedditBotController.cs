using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WD.Botifier.BotRegistry.Application.RedditBots;
using WD.Botifier.BotRegistry.Application.RedditBots.CreateRedditBot;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.SharedKernel;
using WD.Botifier.BotRegistry.Domain.SharedKernel.Bots;

namespace WD.Botifier.BotRegistry.Infrastructure.Api.RedditBots.Controllers.CreateRedditBot;

[ApiController]
public class CreateRedditBotController : ControllerBase
{
    private readonly ILogger<CreateRedditBotController> _logger;
    private readonly CreateRedditBotCommandHandler _commandHandler;

    public CreateRedditBotController(ILogger<CreateRedditBotController> logger, CreateRedditBotCommandHandler commandHandler)
    {
        _logger = logger;
        _commandHandler = commandHandler;
    }

    [Authorize]
    [HttpPost("redditBots", Name = "Create reddit bot")]
    public async Task<IActionResult?> CreateBotAsync([FromBody] CreateRedditBotHttpRequestBody requestBody)
    {
        var userId = this.GetAuthenticatedUserId();
        var command = new CreateRedditBotCommand(userId, new BotName(requestBody.Name));

        var result = await _commandHandler.HandleAsync(command);

        return result.Match<IActionResult>(
            success => Created(string.Empty, null),
            duplicateNameError => Conflict(new ProblemDetails { Title = "Conflict.", Detail = "This user already has a reddit bot with this name."})
            );
    }
}
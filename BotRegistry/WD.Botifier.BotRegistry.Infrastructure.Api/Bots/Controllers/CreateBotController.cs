using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WD.Botifier.BotRegistry.Application.Bots;
using WD.Botifier.BotRegistry.Domain.Bots;

namespace WD.Botifier.BotRegistry.Infrastructure.Api.Bots.Controllers;

[ApiController]
public class CreateBotController : ControllerBase
{
    private readonly ILogger<CreateBotController> _logger;
    private readonly CreateBotCommandHandler _commandHandler;

    public CreateBotController(ILogger<CreateBotController> logger, CreateBotCommandHandler commandHandler)
    {
        _logger = logger;
        _commandHandler = commandHandler;
    }

    //[Authorize]
    [HttpPost("bots", Name = "Create bot")]
    public async Task<IActionResult?> CreateBotAsync([FromBody] CreateBotHttpRequestBody requestBody)
    {
        var userId = this.GetAuthenticatedUserId();
        var command = new CreateBotCommand(userId, new BotName(requestBody.Name));

        var result = await _commandHandler.HandleAsync(command);

        return result.Match<IActionResult>(
            success => Created(string.Empty, null),
            duplicateNameError => Conflict(new ProblemDetails { Title = "Conflict.", Detail = "This user already has a bot with this name."})
            );
    }
}
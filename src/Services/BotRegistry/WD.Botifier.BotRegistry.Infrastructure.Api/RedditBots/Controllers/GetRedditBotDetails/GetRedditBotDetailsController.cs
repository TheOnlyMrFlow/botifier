using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WD.Botifier.BotRegistry.Application.RedditBots.GetRedditBotDetails;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Infrastructure.Api.RedditBots.Controllers.GetRedditBotDetails;

[ApiController]
public class GetRedditBotDetailsController : ControllerBase
{
    private readonly ILogger<GetRedditBotDetailsController> _logger;
    private readonly GetRedditBotDetailsQueryHandler _queryHandler;

    public GetRedditBotDetailsController(ILogger<GetRedditBotDetailsController> logger, GetRedditBotDetailsQueryHandler queryHandler)
    {
        _logger = logger;
        _queryHandler = queryHandler;
    }

    [Authorize]
    [HttpGet("botOwners/{ownerId:guid}/redditBots/{botId:guid}", Name = "Get details of a reddit bot")]
    public async Task<IActionResult> GetRedditBotDetailsAsync(Guid ownerId, Guid botId)
    {
        var userId = this.GetAuthenticatedUserId();
        var query = new GetRedditBotDetailsQuery(userId, new UserId(ownerId), new RedditBotId(botId));

        var result = await _queryHandler.Handle(query);
        
        return result.Match<IActionResult>(success => Ok(success), forbidden => Forbid(), none => NotFound());
    }
}
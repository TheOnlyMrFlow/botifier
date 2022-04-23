using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WD.Botifier.BotRegistry.Application.RedditBots.EditRedditBotCredentials;
using WD.Botifier.BotRegistry.Application.RedditBots.ListRedditBotsOfOwner;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Infrastructure.Api.RedditBots.Controllers.CreateRedditBot;
using WD.Botifier.BotRegistry.Infrastructure.Api.RedditBots.Controllers.EditRedditBotCredentials;

namespace WD.Botifier.BotRegistry.Infrastructure.Api.RedditBots.Controllers.ListAllBotsOwnedByUser;

[ApiController]
public class ListRedditBotsOfOwnerController : ControllerBase
{
    private readonly ILogger<CreateRedditBotController> _logger;
    private readonly ListRedditBotsOfOwnerQueryHandler _queryHandler;

    public ListRedditBotsOfOwnerController(ILogger<CreateRedditBotController> logger, ListRedditBotsOfOwnerQueryHandler queryHandler)
    {
        _logger = logger;
        _queryHandler = queryHandler;
    }

    [Authorize]
    [HttpGet("botOwners/{ownerId:guid}/redditBots", Name = "List all reddit bots of owner")]
    public ActionResult? CreateBotAsync(Guid ownerId)
    {
        var userId = this.GetAuthenticatedUserId();
        var query = new ListRedditBotsOfOwnerQuery(userId);

        var result = _queryHandler.Handle(query);

        return Ok(result);
    }
}
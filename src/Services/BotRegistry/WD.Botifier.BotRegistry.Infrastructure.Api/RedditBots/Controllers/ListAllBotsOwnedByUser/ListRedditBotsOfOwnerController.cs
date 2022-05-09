using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WD.Botifier.BotRegistry.Application.RedditBots.ListRedditBotsOfOwner;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Infrastructure.Api.RedditBots.Controllers.ListAllBotsOwnedByUser;

[ApiController]
public class ListRedditBotsOfOwnerController : ControllerBase
{
    private readonly ILogger<ListRedditBotsOfOwnerController> _logger;
    private readonly ListRedditBotsOfOwnerQueryHandler _queryHandler;

    public ListRedditBotsOfOwnerController(ILogger<ListRedditBotsOfOwnerController> logger, ListRedditBotsOfOwnerQueryHandler queryHandler)
    {
        _logger = logger;
        _queryHandler = queryHandler;
    }

    [Authorize]
    [HttpGet("botOwners/{ownerId:guid}/redditBots", Name = "List all reddit bots of owner")]
    public ActionResult ListRedditBotOfOwnerAsync(Guid ownerId)
    {
        var userId = this.GetAuthenticatedUserId();
        var query = new ListRedditBotsOfOwnerQuery(userId, new UserId(ownerId));

        var result = _queryHandler.Handle(query);

        return result.Match<ActionResult>(success => Ok(success.Bots), forbidden => Forbid());
    }
}
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WD.Botifier.BotRegistry.Application.RedditBots.AddBotUserNameMentionInCommentTrigger;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers;

namespace WD.Botifier.BotRegistry.Infrastructure.Api.RedditBots.Controllers.AddBotUserNameMentionInCommentTrigger;

[ApiController]
public class AddBotUserNameMentionInCommentTriggerController : ControllerBase
{
    private readonly ILogger<AddBotUserNameMentionInCommentTriggerController> _logger;
    private readonly AddBotUserNameMentionInCommentTriggerCommandHandler _addBotUserNameMentionInCommentTriggerCommandHandler;

    public AddBotUserNameMentionInCommentTriggerController(ILogger<AddBotUserNameMentionInCommentTriggerController> logger, AddBotUserNameMentionInCommentTriggerCommandHandler addBotUserNameMentionInCommentTriggerCommandHandler)
    {
        _logger = logger;
        _addBotUserNameMentionInCommentTriggerCommandHandler = addBotUserNameMentionInCommentTriggerCommandHandler;
    }

    [Authorize]
    [HttpPost("redditBots/{botId:guid}/triggers/botUsernameMentionInComment", Name = "Add a new BotUsernameMentionInComment trigger to a reddit bot")]
    public async Task<IActionResult?> AddTriggerAsync(Guid botId, [FromBody] AddBotUserNameMentionInCommentTriggerHttpRequestBody requestBody)
    {
        var userId = this.GetAuthenticatedUserId();
        var command = new AddBotUserNameMentionInCommentTriggerCommand(userId, new RedditBotId(botId), new RedditTriggerName(requestBody.Name));

        var result = await _addBotUserNameMentionInCommentTriggerCommandHandler.HandleAsync(command);

        return result.Match<IActionResult>(
            success => Created(string.Empty, null),
            botNotFoundError => NotFound(new ProblemDetails { Title = "Not found.", Detail = "Bot was not found."})
        );
    }
}
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WD.Botifier.BotRegistry.Application.RedditBots.AddNewPostInSubredditTrigger;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Infrastructure.Api.RedditBots.Controllers.AddBotUserNameMentionInCommentTrigger;
using WD.Botifier.SharedKernel.Reddit;

namespace WD.Botifier.BotRegistry.Infrastructure.Api.RedditBots.Controllers.AddNewPostInSubredditTrigger;

[ApiController]
public class AddNewPostInSubredditTriggerController : ControllerBase
{
    private readonly ILogger<AddBotUserNameMentionInCommentTriggerController> _logger;
    private readonly AddNewPostInSubredditTriggerCommandHandler _addNewPostInSubredditTriggerCommandHandler;

    public AddNewPostInSubredditTriggerController(ILogger<AddBotUserNameMentionInCommentTriggerController> logger, AddNewPostInSubredditTriggerCommandHandler addNewPostInSubredditTriggerCommandHandler)
    {
        _logger = logger;
        _addNewPostInSubredditTriggerCommandHandler = addNewPostInSubredditTriggerCommandHandler;
    }
    
    [Authorize]
    [HttpPost("redditBots/{botId:guid}/triggers/newPostInSubreddit", Name = "Add a new NewPostInSubreddit trigger to a reddit bot")]
    public async Task<IActionResult?> AddTriggerAsync(Guid botId, AddNewPostInSubredditTriggerHttpRequestBody requestBody)
    {
        var userId = this.GetAuthenticatedUserId();
        var command = new AddNewPostInSubredditTriggerCommand(userId, new RedditBotId(botId), requestBody.SubredditNames.Select(sr => new SubredditName(sr)));

        var result = await _addNewPostInSubredditTriggerCommandHandler.HandleAsync(command);

        return result.Match<IActionResult>(
            success => Created(string.Empty, null),
            botNotFoundError => NotFound(new ProblemDetails { Title = "Not found.", Detail = "Bot was not found."})
        );
    }
}
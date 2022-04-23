using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WD.Botifier.BotRegistry.Infrastructure.Api.RedditBots.Controllers.AddNewPostInSubredditTrigger;

public class AddNewPostInSubredditTriggerHttpRequestBody
{
    [MinLength(1)]
    public IEnumerable<string> SubredditNames { get; set; }
}


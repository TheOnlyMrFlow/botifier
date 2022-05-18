using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WD.Botifier.BotRegistry.Infrastructure.Api.RedditBots.Controllers.AddBotUserNameMentionInCommentTrigger;

public class AddBotUserNameMentionInCommentTriggerHttpRequestBody
{
    [Required]
    public string Name { get; set; }
}


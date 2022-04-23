using OneOf;
using WD.Botifier.BotRegistry.Domain.RedditBots;

namespace WD.Botifier.BotRegistry.Application.RedditBots.CreateRedditBot;

[GenerateOneOf]
public partial class CreateRedditBotCommandResult : OneOfBase<CreateRedditBotCommandSuccessResult, CreateRedditBotCommandDuplicateNameForSameOwnerErrorResult> { }

public class CreateRedditBotCommandSuccessResult
{
    public CreateRedditBotCommandSuccessResult(RedditBotId createdRedditBotId)
    {
        RedditBotId = createdRedditBotId;
    }
    
    public RedditBotId RedditBotId { get; }
}

public class CreateRedditBotCommandDuplicateNameForSameOwnerErrorResult
{
}
using OneOf;
using WD.Botifier.BotRegistry.Domain.RedditBots;

namespace WD.Botifier.BotRegistry.Application.RedditBots.EditRedditBotCredentials;

[GenerateOneOf]
public partial class EditRedditBotCredentialsCommandResult : OneOfBase<EditRedditBotCredentialsCommandSuccessResult, EditRedditBotCredentialsCommandBotNotFoundResult> { }

public class EditRedditBotCredentialsCommandSuccessResult
{
}

public class EditRedditBotCredentialsCommandBotNotFoundResult
{
}
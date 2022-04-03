using OneOf;

namespace WD.Botifier.BotRegistry.Application.RedditBots.AddNewPostInSubredditTrigger;

[GenerateOneOf]
public partial class AddNewPostInSubredditTriggerCommandResult : OneOfBase<AddNewPostInSubredditTriggerCommandSuccessResult, AddNewPostInSubredditTriggerCommandBotNotFoundResult>
{
}

public class AddNewPostInSubredditTriggerCommandSuccessResult
{
}

public class AddNewPostInSubredditTriggerCommandBotNotFoundResult
{
}
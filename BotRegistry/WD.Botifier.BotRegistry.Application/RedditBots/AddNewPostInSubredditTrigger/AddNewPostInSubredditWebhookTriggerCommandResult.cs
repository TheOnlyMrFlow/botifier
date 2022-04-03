using OneOf;

namespace WD.Botifier.BotRegistry.Application.RedditBots.AddNewPostInSubredditTrigger;

[GenerateOneOf]
public partial class AddNewPostInSubredditTriggerCommandResult : OneOfBase<AddNewPostInSubredditTriggerCommandSuccessResult, AddNewPostInSubredditTriggerCommandBotNotFounResult>
{
}

public class AddNewPostInSubredditTriggerCommandSuccessResult
{
}

public class AddNewPostInSubredditTriggerCommandBotNotFounResult
{
}
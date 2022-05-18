using OneOf;

namespace WD.Botifier.BotRegistry.Application.RedditBots.RemoveWebhookFromTrigger;

[GenerateOneOf]
public partial class RemoveWebhookFromTriggerCommandResult : OneOfBase<RemoveWebhookFromTriggerCommandSuccessResult, RemoveWebhookFromTriggerCommandBotNotFoundResult, RemoveWebhookFromTriggerCommandTriggerNotFoundResult>
{
}

public class RemoveWebhookFromTriggerCommandSuccessResult
{
}

public class RemoveWebhookFromTriggerCommandBotNotFoundResult
{
}

public class RemoveWebhookFromTriggerCommandTriggerNotFoundResult
{
}
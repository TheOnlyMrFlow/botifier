using OneOf;

namespace WD.Botifier.BotRegistry.Application.RedditBots.AddWebhookToTrigger;

[GenerateOneOf]
public partial class AddWebhookToTriggerCommandResult : OneOfBase<AddWebhookToTriggerCommandSuccessResult, AddWebhookToTriggerCommandBotNotFoundResult>
{
}

public class AddWebhookToTriggerCommandSuccessResult
{
}

public class AddWebhookToTriggerCommandBotNotFoundResult
{
}
using OneOf;

namespace WD.Botifier.BotRegistry.Application.RedditBots.AddWebhookToTrigger;

[GenerateOneOf]
public partial class AddWebhookToTriggerCommandResult : OneOfBase<AddWebhookToTriggerCommandSuccessResult, AddWebhookToTriggerCommandBotNotFoundResult, AddWebhookToTriggerTriggerNotFoundResult, AddWebhookToTriggerWebhookNameAlreadyExistsResult>
{
}

public class AddWebhookToTriggerCommandSuccessResult
{
}

public class AddWebhookToTriggerCommandBotNotFoundResult
{
}

public class AddWebhookToTriggerTriggerNotFoundResult
{
}

public class AddWebhookToTriggerWebhookNameAlreadyExistsResult
{
}
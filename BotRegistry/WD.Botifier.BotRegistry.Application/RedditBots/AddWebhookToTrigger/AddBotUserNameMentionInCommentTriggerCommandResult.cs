using OneOf;

namespace WD.Botifier.BotRegistry.Application.RedditBots.AddWebhookToTrigger;

[GenerateOneOf]
public partial class AddWebhookToTriggerCommandResult : OneOfBase<AddWebhookToTriggerCommandSuccessResult, AddWebhookToTriggerCommandBotNotFounResult>
{
}

public class AddWebhookToTriggerCommandSuccessResult
{
}

public class AddWebhookToTriggerCommandBotNotFounResult
{
}
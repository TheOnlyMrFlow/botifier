using OneOf;
using WD.Botifier.BotRegistry.Domain.Bots;

namespace WD.Botifier.BotRegistry.Application.Bots;

[GenerateOneOf]
public partial class CreateBotCommandResult : OneOfBase<CreateBotCommandSuccessResult, CreateBotCommandDuplicateNameForSameOwnerErrorResult> { }

public class CreateBotCommandSuccessResult
{
    public CreateBotCommandSuccessResult(BotId createdBotId)
    {
        BotId = createdBotId;
    }
    
    public BotId BotId { get; }
}

public class CreateBotCommandDuplicateNameForSameOwnerErrorResult
{
}
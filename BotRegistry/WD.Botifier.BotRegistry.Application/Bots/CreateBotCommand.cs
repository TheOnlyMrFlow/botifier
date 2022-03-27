using WD.Botifier.BotRegistry.Domain.Bots;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Application.Bots;

public class CreateBotCommand
{
    public CreateBotCommand(UserId ownerId, BotName botName)
    {
        OwnerId = ownerId;
        BotName = botName;
    }
    
    public UserId OwnerId { get; }
    
    public BotName BotName { get; }
}
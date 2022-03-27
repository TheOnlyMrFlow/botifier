using System.Threading.Tasks;
using WD.Botifier.BotRegistry.Domain.Bots;

namespace WD.Botifier.BotRegistry.Application.Bots;

public class CreateBotCommandHandler
{
    private readonly IBotRepository _botRepository;

    public CreateBotCommandHandler(IBotRepository botRepository)
    {
        _botRepository = botRepository;
    }

    public async Task<CreateBotCommandResult> HandleAsync(CreateBotCommand command)
    {
        var bot = Bot.NewBot(command.OwnerId, command.BotName);

        if (await _botRepository.BotNameExistsForOwner(command.OwnerId, command.BotName))
            return new CreateBotCommandDuplicateNameForSameOwnerErrorResult();

        await _botRepository.AddAsync(bot);

        return new CreateBotCommandSuccessResult(bot.Id);
    }
}
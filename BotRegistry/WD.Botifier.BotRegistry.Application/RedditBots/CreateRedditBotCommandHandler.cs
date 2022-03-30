using System.Threading.Tasks;
using WD.Botifier.BotRegistry.Domain.RedditBots;

namespace WD.Botifier.BotRegistry.Application.RedditBots;

public class CreateRedditBotCommandHandler
{
    private readonly IRedditBotRepository _redditBotRepository;

    public CreateRedditBotCommandHandler(IRedditBotRepository redditBotRepository)
    {
        _redditBotRepository = redditBotRepository;
    }

    public async Task<CreateRedditBotCommandResult> HandleAsync(CreateRedditBotCommand command)
    {
        var bot = RedditBot.NewBot(command.OwnerId, command.RedditBotName);

        if (await _redditBotRepository.BotNameExistsForOwner(command.OwnerId, command.RedditBotName))
            return new CreateRedditBotCommandDuplicateNameForSameOwnerErrorResult();

        await _redditBotRepository.AddAsync(bot);

        return new CreateRedditBotCommandSuccessResult(bot.Id);
    }
}
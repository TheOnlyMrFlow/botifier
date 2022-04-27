using System;
using System.Threading.Tasks;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.Infra.IntegrationEventBus.RabbitMQ;
using WD.Botifier.SeedWork;

namespace WD.Botifier.BotRegistry.Application.RedditBots.CreateRedditBot;

public class CreateRedditBotCommandHandler
{
    private readonly IRedditBotRepository _redditBotRepository;

    public CreateRedditBotCommandHandler(IRedditBotRepository redditBotRepository)
    {
        _redditBotRepository = redditBotRepository;
    }

    public async Task<CreateRedditBotCommandResult> HandleAsync(CreateRedditBotCommand command)
    {
        var bot = RedditBot.NewBot(command.UserId, command.BotName);

        if (await _redditBotRepository.BotNameExistsForOwnerAsync(command.UserId, command.BotName))
            return new CreateRedditBotCommandDuplicateNameForSameOwnerErrorResult();

        await _redditBotRepository.AddAsync(bot);

        return new CreateRedditBotCommandSuccessResult(bot.Id);
    }
}

public class TotoEvent : IIntegrationEvent
{
    public string EmitterServiceName => "TotoService";
    public DateTime OccuredOn { get; } = DateTime.UtcNow;
}
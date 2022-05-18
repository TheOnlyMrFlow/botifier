using System.Threading.Tasks;
using WD.Botifier.BotRegistry.Domain.RedditBots;

namespace WD.Botifier.BotRegistry.Application.RedditBots.RemoveWebhookFromTrigger;

public class RemoveWebhookFromTriggerCommandHandler
{
    private readonly IRedditBotRepository _redditBotRepository;

    public RemoveWebhookFromTriggerCommandHandler(IRedditBotRepository redditBotRepository)
    {
        _redditBotRepository = redditBotRepository;
    }

    public async Task<RemoveWebhookFromTriggerCommandResult> HandleAsync(RemoveWebhookFromTriggerCommand command)
    {
        var bot = await _redditBotRepository.GetAsync(command.UserId, command.BotId);
        if (bot is null)
            return new RemoveWebhookFromTriggerCommandBotNotFoundResult();

        try
        {
            bot.RemoveWebhookFromTrigger(command.TriggerId, command.WebhookName);
            await _redditBotRepository.UpdateAsync(bot);
            return new RemoveWebhookFromTriggerCommandSuccessResult();
        }
        catch (TriggerDoesNotExistException e)
        {
            return new RemoveWebhookFromTriggerCommandTriggerNotFoundResult();
        }
    }
}
using System.Threading.Tasks;
using WD.Botifier.BotRegistry.Application.RedditBots.AddWebhookToRedditBot;
using WD.Botifier.BotRegistry.Domain.RedditBots;

namespace WD.Botifier.BotRegistry.Application.RedditBots.AddBotUserMentionInCommentWebhookToRedditBot;

public class AddWebhookToRedditCommandHandler
{
    private readonly IRedditBotRepository _redditBotRepository;

    public AddWebhookToRedditCommandHandler(IRedditBotRepository redditBotRepository)
    {
        _redditBotRepository = redditBotRepository;
    }

    public async Task<AddWebhookToRedditBotCommandResult> HandleAsync(AddWebhookToRedditBotCommand command)
    {
        var webhook = new AddBotUserMentionInCommentWebhookToRedditBot
        
        var bot = RedditBot.NewBot(command.UserId, command.BotName);

        if (await _redditBotRepository.BotNameExistsForOwner(command.UserId, command.BotName))
            return new CreateRedditBotCommandDuplicateNameForSameOwnerErrorResult();

        await _redditBotRepository.AddAsync(bot);

        return new CreateRedditBotCommandSuccessResult(bot.Id);
    }
}
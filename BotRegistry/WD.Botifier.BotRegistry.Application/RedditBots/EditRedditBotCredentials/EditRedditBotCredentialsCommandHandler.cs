using System.Threading.Tasks;
using WD.Botifier.BotRegistry.Application.RedditBots.CreateRedditBot;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.RedditBots.Credentials;

namespace WD.Botifier.BotRegistry.Application.RedditBots.EditRedditBotCredentials;

public class EditRedditBotCredentialsCommandHandler
{
    private readonly IRedditBotRepository _redditBotRepository;

    public EditRedditBotCredentialsCommandHandler(IRedditBotRepository redditBotRepository)
    {
        _redditBotRepository = redditBotRepository;
    }

    public async Task<EditRedditBotCredentialsCommandResult> HandleAsync(EditRedditBotCredentialsCommand command)
    {
        var bot = await _redditBotRepository.GetAsync(command.UserId, command.BotId);

        if (bot is null)
            return new EditRedditBotCredentialsCommandBotNotFoundResult();

        var credentials = new RedditBotCredentials(command.UserName, command.Password, command.ClientId, command.ClientSecret);
        bot.SetCredentials(credentials);

        await _redditBotRepository.UpdateAsync(bot);

        return new EditRedditBotCredentialsCommandSuccessResult();
    }
}
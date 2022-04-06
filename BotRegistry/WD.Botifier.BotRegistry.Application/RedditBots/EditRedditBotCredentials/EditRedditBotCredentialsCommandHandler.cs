using System.Threading.Tasks;
using WD.Botifier.BotRegistry.Application.RedditBots.CreateRedditBot;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.SharedKernel.Reddit.AppCredentials;

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

        var credentials = new RedditAppCredentials(command.UserName, command.Password, command.AppClientId, command.AppClientSecret);
        bot.SetCredentials(credentials);

        await _redditBotRepository.UpdateAsync(bot);

        return new EditRedditBotCredentialsCommandSuccessResult();
    }
}
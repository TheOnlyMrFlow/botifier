using System.Threading.Tasks;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.NewPostInSubreddit;

namespace WD.Botifier.BotRegistry.Application.RedditBots.AddNewPostInSubredditTrigger;

public class AddNewPostInSubredditTriggerCommandHandler
{
    private readonly IRedditBotRepository _redditBotRepository;

    public AddNewPostInSubredditTriggerCommandHandler(IRedditBotRepository redditBotRepository)
    {
        _redditBotRepository = redditBotRepository;
    }

    public async Task<AddNewPostInSubredditTriggerCommandResult> HandleAsync(AddNewPostInSubredditTriggerCommand command)
    {
        var bot = await _redditBotRepository.GetAsync(command.UserId, command.BotId);
        if (bot is null)
            return new AddNewPostInSubredditTriggerCommandBotNotFoundResult();

        var triggerSettings = new NewPostInSubredditTriggerSettings(command.SubredditNames);
        bot.AddNewTrigger(triggerSettings);

        await _redditBotRepository.UpdateAsync(bot);
        
        return new AddNewPostInSubredditTriggerCommandSuccessResult();
    }
}
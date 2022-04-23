using System.Threading.Tasks;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.BotUserNameMentionInComment;

namespace WD.Botifier.BotRegistry.Application.RedditBots.AddBotUserNameMentionInCommentTrigger;

public class AddBotUserNameMentionInCommentTriggerCommandHandler
{
    private readonly IRedditBotRepository _redditBotRepository;

    public AddBotUserNameMentionInCommentTriggerCommandHandler(IRedditBotRepository redditBotRepository)
    {
        _redditBotRepository = redditBotRepository;
    }

    public async Task<AddBotUserNameMentionInCommentTriggerCommandResult> HandleAsync(AddBotUserNameMentionInCommentTriggerCommand command)
    {
        var bot = await _redditBotRepository.GetAsync(command.UserId, command.BotId);
        if (bot is null)
            return new AddBotUserNameMentionInCommentTriggerCommandBotNotFoundResult();

        bot.AddNewTrigger(new BotUserNameMentionInCommentTriggerSettings());

        await _redditBotRepository.UpdateAsync(bot);
        
        return new AddBotUserNameMentionInCommentTriggerCommandSuccessResult();
    }
}
using System;
using System.Threading.Tasks;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.BotUserNameMentionInComment;
using WD.Botifier.BotRegistry.Domain.RedditBots.Webhooks;

namespace WD.Botifier.BotRegistry.Application.RedditBots.AddBotUserNameMentionInCommentWebhook;

public class AddWebhookToRedditCommandHandler
{
    private readonly IRedditBotRepository _redditBotRepository;

    public AddWebhookToRedditCommandHandler(IRedditBotRepository redditBotRepository)
    {
        _redditBotRepository = redditBotRepository;
    }

    public async Task<AddBotUserNameMentionInCommentWebhookCommandResult> HandleAsync(AddBotUserNameMentionInCommentWebhookCommand command)
    {
        var bot = await _redditBotRepository.GetAsync(command.UserId, command.BotId);
        if (bot is null)
            return new AddBotUserNameMentionInCommentWebhookCommandBotNotFounResult();

        var trigger = BotUserNameMentionInCommentTrigger.NewBotUserNameMentionInCommentTrigger();
        var webhook = RedditWebhook<BotUserNameMentionInCommentTrigger>.NewRedditWebhook(command.WebhookName, command.WebhookUrl, trigger);

        bot.AddWebhook(webhook);

        await _redditBotRepository.UpdateAsync(bot);
        
        return new AddBotUserNameMentionInCommentWebhookCommandSuccessResult();
    }
}
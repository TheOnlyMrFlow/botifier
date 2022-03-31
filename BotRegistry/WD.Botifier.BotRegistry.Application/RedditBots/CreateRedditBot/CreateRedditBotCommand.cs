using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.SharedKernel;
using WD.Botifier.BotRegistry.Domain.SharedKernel.Bots;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Application.RedditBots.CreateRedditBot;

public class CreateRedditBotCommand : AuthenticatedCommandBase
{
    public CreateRedditBotCommand(UserId userId, BotName botName) : base(userId)
    {
        BotName = botName;
    }

    public BotName BotName { get; }
}
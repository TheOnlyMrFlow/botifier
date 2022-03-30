using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Application.RedditBots;

public class CreateRedditBotCommand
{
    public CreateRedditBotCommand(UserId ownerId, RedditBotName redditBotName)
    {
        OwnerId = ownerId;
        RedditBotName = redditBotName;
    }
    
    public UserId OwnerId { get; }
    
    public RedditBotName RedditBotName { get; }
}
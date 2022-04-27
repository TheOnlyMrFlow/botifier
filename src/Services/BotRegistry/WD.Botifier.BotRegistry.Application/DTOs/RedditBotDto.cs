using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.SharedKernel.Bots;

namespace WD.Botifier.BotRegistry.Application.DTOs;

public class RedditBotDto
{
    public string Id { get; }
    public BotName Name { get; }

    public RedditBotDto(RedditBot redditBot)
    {
        Id = redditBot.Id.Value.ToString();
        Name = redditBot.Name;
    }
}
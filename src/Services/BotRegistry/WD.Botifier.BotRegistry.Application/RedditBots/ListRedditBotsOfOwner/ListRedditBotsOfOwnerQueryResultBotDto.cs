using System;
using OneOf.Types;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Application.RedditBots.ListRedditBotsOfOwner;

public class ListRedditBotsOfOwnerQueryResultBotDto
{
    public ListRedditBotsOfOwnerQueryResultBotDto(RedditBot redditBot)
    {
        Id = redditBot.Id.Value.ToString();
        OwnerId = redditBot.OwnerId.Value.ToString();
        Name = redditBot.Name.Value;
        CreatedAt = redditBot.CreatedAt;
    }
    
    public string Id { get; }
    public string OwnerId { get; }
    public string Name { get; }
    public DateTime CreatedAt { get; }
}
using System.Collections.Generic;
using System.Linq;
using WD.Botifier.BotRegistry.Domain.RedditBots;

namespace WD.Botifier.BotRegistry.Application.RedditBots.ListRedditBotsOfOwner;

public class ListRedditBotsOfOwnerQueryHandler
{
    private readonly IRedditBotRepository _redditBotRepository;

    public ListRedditBotsOfOwnerQueryHandler(IRedditBotRepository redditBotRepository)
    {
        _redditBotRepository = redditBotRepository;
    }

    public IEnumerable<ListRedditBotsOfOwnerQueryResultBotDto> Handle(ListRedditBotsOfOwnerQuery query)
    {
        var bots = _redditBotRepository.Search(new IRedditBotRepository.SearchRedditBotOptions(query.UserId));

        return bots.Select(b => new ListRedditBotsOfOwnerQueryResultBotDto(b));
    }
}
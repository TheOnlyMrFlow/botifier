using System.Collections.Generic;
using System.Linq;
using OneOf;
using WD.Botifier.BotRegistry.Domain.RedditBots;

namespace WD.Botifier.BotRegistry.Application.RedditBots.ListRedditBotsOfOwner;

public class ListRedditBotsOfOwnerQueryHandler
{
    private readonly IRedditBotRepository _redditBotRepository;

    public ListRedditBotsOfOwnerQueryHandler(IRedditBotRepository redditBotRepository)
    {
        _redditBotRepository = redditBotRepository;
    }

    public ListRedditBotsOfOwnerQueryResult Handle(ListRedditBotsOfOwnerQuery query)
    {
        if (query.UserId != query.OwnerId){}
            return new ListRedditBotsOfOwnerQueryForbiddenResult();
        
        var bots = _redditBotRepository.Search(new IRedditBotRepository.SearchRedditBotOptions(query.UserId));

        return new ListRedditBotsOfOwnerQuerySuccessResult(bots.Select(b => new ListRedditBotsOfOwnerQueryResultBotDto(b)));
    }
}
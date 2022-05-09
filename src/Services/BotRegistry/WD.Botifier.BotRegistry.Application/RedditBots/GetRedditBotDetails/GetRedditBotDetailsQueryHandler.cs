using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneOf;
using OneOf.Types;
using WD.Botifier.BotRegistry.Application.RedditBots.ListRedditBotsOfOwner;
using WD.Botifier.BotRegistry.Domain.RedditBots;

namespace WD.Botifier.BotRegistry.Application.RedditBots.GetRedditBotDetails;

public class GetRedditBotDetailsQueryHandler
{
    private readonly IRedditBotRepository _redditBotRepository;

    public GetRedditBotDetailsQueryHandler(IRedditBotRepository redditBotRepository)
    {
        _redditBotRepository = redditBotRepository;
    }

    public async Task<GetRedditBotDetailsQueryResult> Handle(GetRedditBotDetailsQuery query)
    {
        if (query.UserId != query.OwnerId)
            return new GetRedditBotDetailsQueryForbiddenResult();
        
        var bot = await _redditBotRepository.GetAsync(query.UserId, query.BotId);
        
        if (bot is null)
            return new None();

        return new GetRedditBotDetailsQueryResultDto(bot);
    }
}
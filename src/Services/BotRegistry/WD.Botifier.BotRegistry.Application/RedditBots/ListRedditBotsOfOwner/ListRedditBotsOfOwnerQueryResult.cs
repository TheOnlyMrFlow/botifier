using System.Collections.Generic;
using OneOf;

namespace WD.Botifier.BotRegistry.Application.RedditBots.ListRedditBotsOfOwner;

[GenerateOneOf]
public partial class ListRedditBotsOfOwnerQueryResult : OneOfBase<ListRedditBotsOfOwnerQuerySuccessResult, ListRedditBotsOfOwnerQueryForbiddenResult> { }

public class ListRedditBotsOfOwnerQuerySuccessResult
{
    public IEnumerable<ListRedditBotsOfOwnerQueryResultBotDto> Bots { get; }

    public ListRedditBotsOfOwnerQuerySuccessResult(IEnumerable<ListRedditBotsOfOwnerQueryResultBotDto> bots)
    {
        Bots = bots;
    }
}

public class ListRedditBotsOfOwnerQueryForbiddenResult {}

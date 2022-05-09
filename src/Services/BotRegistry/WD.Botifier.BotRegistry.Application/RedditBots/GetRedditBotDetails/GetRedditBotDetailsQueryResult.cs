using OneOf;
using OneOf.Types;

namespace WD.Botifier.BotRegistry.Application.RedditBots.GetRedditBotDetails;

[GenerateOneOf]
public partial class GetRedditBotDetailsQueryResult : OneOfBase<GetRedditBotDetailsQueryResultDto, GetRedditBotDetailsQueryForbiddenResult, None>
{
}

public class GetRedditBotDetailsQueryForbiddenResult {}

using WD.Botifier.RedditBotRunner.Application.Ports;
using WD.Botifier.RedditBotRunner.Domain.Bots;

namespace WD.Botifier.RedditBotRunner.Infra.RedditWatcher.RedditDotNet;

public class AuthfulRedditApiClientFactory : IAuthfulRedditApiFactory
{
    IAuthfulRedditApi IAuthfulRedditApiFactory.Create(RedditRefreshToken refreshToken)
        => new RedditApiClient(refreshToken);
}
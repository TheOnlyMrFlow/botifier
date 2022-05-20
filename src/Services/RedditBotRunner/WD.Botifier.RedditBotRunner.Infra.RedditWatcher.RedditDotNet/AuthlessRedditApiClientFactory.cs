using WD.Botifier.RedditBotRunner.Application.Ports;
using WD.Botifier.RedditBotRunner.Domain.Bots;

namespace WD.Botifier.RedditBotRunner.Infra.RedditWatcher.RedditDotNet;

public class AuthlessRedditApiClientFactorySettings
{
    public string RefreshToken { get; set; }
}

public class AuthlessRedditApiClientFactory : IAuthlessRedditApiFactory
{
    private readonly RedditRefreshToken _refreshToken;

    public AuthlessRedditApiClientFactory(AuthlessRedditApiClientFactorySettings settings)
    {
        _refreshToken = new RedditRefreshToken(settings.RefreshToken);
    }

    IAuthlessRedditApi IAuthlessRedditApiFactory.Create()
        => new RedditApiClient(_refreshToken);
}
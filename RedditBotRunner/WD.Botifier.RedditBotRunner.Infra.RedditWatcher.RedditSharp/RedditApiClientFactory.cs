using System;
using WD.Botifier.RedditBotRunner.Application.Ports;
using WD.Botifier.SharedKernel.Reddit;
using WD.Botifier.SharedKernel.Reddit.AppCredentials;

namespace WD.Botifier.RedditBotRunner.Infra.RedditApIClient;

public class RedditApiClientFactory : IAuthfulRedditApiFactory, IAuthlessRedditApiFactory
{
    private readonly RedditAppCredentials _authlessAppCredentials;

    public RedditApiClientFactory(RedditApiClientFactoryConfiguration config)
    {
        _authlessAppCredentials =new RedditAppCredentials(new RedditUserName(config.UserName), new RedditPassword(config.Password), new RedditAppClientId(config.ClientId), new RedditAppClientSecret(config.ClientSecret), new RedditAppRedirectUri(config.RedirectUri));
    }

    IAuthfulRedditApi IAuthfulRedditApiFactory.Create(RedditAppCredentials appCredentials)
        => new RedditApiClient(appCredentials);

    IAuthlessRedditApi IAuthlessRedditApiFactory.Create()
        => new RedditApiClient(_authlessAppCredentials);
}

public class RedditApiClientFactoryConfiguration
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string RedirectUri { get; set; }
}
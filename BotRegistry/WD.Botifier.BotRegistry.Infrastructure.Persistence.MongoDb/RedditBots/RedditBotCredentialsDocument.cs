using System;
using WD.Botifier.SharedKernel.Reddit;
using WD.Botifier.SharedKernel.Reddit.AppCredentials;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots;

public class RedditBotCredentialsDocument
{
    public RedditBotCredentialsDocument(RedditAppCredentials redditAppCredentials)
    {
        UserName = redditAppCredentials.UserName.WithoutUSlash;
        Password = redditAppCredentials.Password.Value;
        ClientId = redditAppCredentials.AppClientId.Value;
        ClientSecret = redditAppCredentials.AppClientSecret.Value;
        RedirectUri = redditAppCredentials.RedirectUri.ToString();
    }
    
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string? RedirectUri { get; set; }
    
    public RedditAppCredentials ToRedditBotCredentials() 
        => new(
            new RedditUserName(UserName),
            new RedditPassword(Password),
            new RedditAppClientId(ClientId),
            new RedditAppClientSecret(ClientSecret),
            new Uri(RedirectUri ?? string.Empty)
        );
}
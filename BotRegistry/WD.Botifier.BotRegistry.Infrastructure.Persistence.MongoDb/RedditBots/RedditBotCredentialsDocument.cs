using WD.Botifier.SharedKernel.Reddit.AppCredentials;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots;

public class RedditBotCredentialsDocument
{
    public RedditBotCredentialsDocument(RedditAppCredentials redditAppCredentials)
    {
        UserName = redditAppCredentials.UserName.Value;
        Password = redditAppCredentials.Password.Value;
        ClientId = redditAppCredentials.AppClientId.Value;
        ClientSecret = redditAppCredentials.AppClientSecret.Value;
    }
    
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    
    public RedditAppCredentials ToRedditBotCredentials() 
        => new(
            new RedditUserName(UserName),
            new RedditPassword(Password),
            new RedditAppClientId(ClientId),
            new RedditAppClientSecret(ClientSecret)
        );
}
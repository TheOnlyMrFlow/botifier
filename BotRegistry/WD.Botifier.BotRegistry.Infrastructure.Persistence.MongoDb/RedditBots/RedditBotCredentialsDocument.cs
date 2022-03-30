using WD.Botifier.BotRegistry.Domain.RedditBots.Credentials;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots;

public class RedditBotCredentialsDocument
{
    public RedditBotCredentialsDocument(RedditBotCredentials redditBotCredentials)
    {
        UserName = redditBotCredentials.UserName.Value;
        Password = redditBotCredentials.Password.Value;
        ClientId = redditBotCredentials.ClientId.Value;
        ClientSecret = redditBotCredentials.ClientSecret.Value;
    }
    
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    
    public RedditBotCredentials ToRedditBotCredentials() 
        => new(
            new RedditUserName(UserName),
            new RedditPassword(Password),
            new RedditClientId(ClientId),
            new RedditClientSecret(ClientSecret)
        );
}
namespace WD.Botifier.BotRegistry.Domain.RedditBots.Credentials;

public class RedditBotCredentials
{
    public RedditBotCredentials(RedditUserName userName, RedditPassword password, RedditClientId clientId, RedditClientSecret clientSecret)
    {
        UserName = userName;
        Password = password;
        ClientId = clientId;
        ClientSecret = clientSecret;
    }
        
    public RedditUserName UserName { get; }
    public RedditPassword Password { get; }
    public RedditClientId ClientId { get; }
    public RedditClientSecret ClientSecret { get; }
    
    public static RedditBotCredentials EmptyCredentials() 
        => new(new RedditUserName(string.Empty), new RedditPassword(string.Empty), new RedditClientId(string.Empty), new RedditClientSecret(string.Empty));
}
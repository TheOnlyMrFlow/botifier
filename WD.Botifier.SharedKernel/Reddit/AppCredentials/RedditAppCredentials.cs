namespace WD.Botifier.SharedKernel.Reddit.AppCredentials;

public class RedditAppCredentials
{
    public RedditAppCredentials(RedditUserName userName, RedditPassword password, RedditAppClientId appClientId, RedditAppClientSecret appClientSecret)
    {
        UserName = userName;
        Password = password;
        AppClientId = appClientId;
        AppClientSecret = appClientSecret;
    }
        
    public RedditUserName UserName { get; }
    public RedditPassword Password { get; }
    public RedditAppClientId AppClientId { get; }
    public RedditAppClientSecret AppClientSecret { get; }
    
    public static RedditAppCredentials EmptyCredentials() 
        => new(new RedditUserName(string.Empty), new RedditPassword(string.Empty), new RedditAppClientId(string.Empty), new RedditAppClientSecret(string.Empty));
}
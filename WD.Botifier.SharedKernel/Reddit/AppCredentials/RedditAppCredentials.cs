using System;

namespace WD.Botifier.SharedKernel.Reddit.AppCredentials;

public class RedditAppCredentials
{
    public RedditAppCredentials(RedditUserName userName, RedditPassword password, RedditAppClientId appClientId, RedditAppClientSecret appClientSecret, Uri redirectUri)
    {
        UserName = userName;
        Password = password;
        AppClientId = appClientId;
        AppClientSecret = appClientSecret;
        RedirectUri = redirectUri;
    }
        
    public RedditUserName UserName { get; }
    public RedditPassword Password { get; }
    public RedditAppClientId AppClientId { get; }
    public RedditAppClientSecret AppClientSecret { get; }
    public Uri RedirectUri { get; set; }

    public static RedditAppCredentials EmptyCredentials() 
        => new(new RedditUserName(string.Empty), new RedditPassword(string.Empty), new RedditAppClientId(string.Empty), new RedditAppClientSecret(string.Empty), new Uri(string.Empty));
}
using System;
using WD.Botifier.SeedWork;

namespace WD.Botifier.SharedKernel.Reddit.AppCredentials;

public class RedditAppCredentials : ValueObject
{
    public RedditAppCredentials(RedditUserName userName, RedditPassword password, RedditAppClientId appClientId, RedditAppClientSecret appClientSecret, RedditAppRedirectUri redirectUri)
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
    public RedditAppRedirectUri RedirectUri { get; set; }

    public static RedditAppCredentials EmptyCredentials() 
        => new(new RedditUserName(string.Empty), new RedditPassword(string.Empty), new RedditAppClientId(string.Empty), new RedditAppClientSecret(string.Empty), new RedditAppRedirectUri(string.Empty));
}
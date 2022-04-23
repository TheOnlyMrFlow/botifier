using WD.Botifier.Authentication.Domain.Users;

namespace WD.Botifier.Authentication.Application.Users.ValidateAccessToken;

public class ValidateAccessTokenQuery
{
    public ValidateAccessTokenQuery(AccessToken accessToken)
    {
        AccessToken = accessToken;
    }
    
    public AccessToken AccessToken { get; }
}
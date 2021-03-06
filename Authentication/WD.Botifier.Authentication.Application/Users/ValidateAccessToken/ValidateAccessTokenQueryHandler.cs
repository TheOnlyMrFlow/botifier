using OneOf.Types;
using WD.Botifier.Authentication.Application.Ports;

namespace WD.Botifier.Authentication.Application.Users.ValidateAccessToken;

public class ValidateAccessTokenQueryHandler
{
    private readonly IAccessTokenManager _accessTokenManager;

    public ValidateAccessTokenQueryHandler(IAccessTokenManager accessTokenManager)
    {
        _accessTokenManager = accessTokenManager;
    }
    
    public ValidateAccessTokenQueryResult Handle(ValidateAccessTokenQuery query)
    {
        return _accessTokenManager.IsValid(query.AccessToken, out var decodedToken)
            ? decodedToken
            : new ValidateAccessTokenQueryInvalidTokenResult();
    }
}
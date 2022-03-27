using OneOf;
using OneOf.Types;
using WD.Botifier.Authentication.Domain.Users;

namespace WD.Botifier.Authentication.Application.Users.Login;

[GenerateOneOf]
public partial class LoginCommandResult : OneOfBase<LoginCommandSuccessResult, Error> { }

public class LoginCommandSuccessResult
{
    public LoginCommandSuccessResult(AccessToken accessToken)
    {
        AccessToken = accessToken;
    }

    public AccessToken AccessToken { get; }
}
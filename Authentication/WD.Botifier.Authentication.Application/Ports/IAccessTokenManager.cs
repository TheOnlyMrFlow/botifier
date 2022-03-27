using WD.Botifier.Authentication.Domain.Users;

namespace WD.Botifier.Authentication.Application.Ports;

public interface IAccessTokenManager
{
    AccessToken Build(User user);
    bool IsValid(AccessToken accessToken);
}
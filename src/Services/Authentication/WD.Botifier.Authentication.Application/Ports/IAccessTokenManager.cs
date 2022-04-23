using System.Collections.Generic;
using WD.Botifier.Authentication.Domain.Users;

namespace WD.Botifier.Authentication.Application.Ports;

public interface IAccessTokenManager
{
    AccessToken Build(User user);
    bool IsValid(AccessToken accessToken, out Dictionary<string, string> decodedToken);
}
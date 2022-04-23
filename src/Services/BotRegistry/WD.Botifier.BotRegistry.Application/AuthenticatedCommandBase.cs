using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Application;

public class AuthenticatedCommandBase : IAuthenticatedCommand
{
    public AuthenticatedCommandBase(UserId userId)
    {
        UserId = userId;
    }

    public UserId UserId { get; }
}
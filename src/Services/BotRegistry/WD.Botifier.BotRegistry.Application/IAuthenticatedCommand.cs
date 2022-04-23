using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Application;

public interface IAuthenticatedCommand : ICommand
{
    UserId UserId { get; }
}
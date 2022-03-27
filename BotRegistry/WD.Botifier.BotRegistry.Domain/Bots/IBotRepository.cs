using System.Threading.Tasks;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Domain.Bots;

public interface IBotRepository
{
    Task<bool> BotNameExistsForOwner(UserId ownerId, BotName botName);
    
    Task AddAsync(Bot bot);
}
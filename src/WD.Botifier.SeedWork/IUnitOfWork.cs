using System.Threading;
using System.Threading.Tasks;

namespace WD.Botifier.SeedWork;

public interface IUnitOfWork
{
    Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
}
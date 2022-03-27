namespace WD.Botifier.SeedWork;

public interface IUnitOfWork
{
    Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
}
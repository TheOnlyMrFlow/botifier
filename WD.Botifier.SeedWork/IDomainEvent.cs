
namespace WD.Botifier.SeedWork;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}
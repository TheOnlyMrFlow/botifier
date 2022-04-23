namespace WD.Botifier.SeedWork;

public interface IDomainEventEmitter
{
    void Emit<TEvent>(TEvent domainEvent) where TEvent : IDomainEvent;
}
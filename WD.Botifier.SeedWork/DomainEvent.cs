namespace WD.Botifier.SeedWork;

public class DomainEvent : IDomainEvent
{
    public DomainEvent()
    {
        OccurredOn = DateTime.Now;
    }

    public DateTime OccurredOn { get; }
}
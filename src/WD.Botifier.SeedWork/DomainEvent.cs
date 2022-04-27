using System;

namespace WD.Botifier.SeedWork;

public abstract class DomainEvent : IDomainEvent
{
    protected DomainEvent()
    {
        OccurredOn = DateTime.Now;
    }

    public DateTime OccurredOn { get; }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace WD.Botifier.SeedWork;

public class DomainEventBus : IDomainEventEmitter
{
    private ICollection<Delegate> _handlers = new List<Delegate>();

    public void Emit<TEvent>(TEvent @event) where TEvent : IDomainEvent
    {
        foreach (var action in _handlers.Where(a => a is Action<TEvent>))
            ((Action<TEvent>)action)(@event);
    }

    public void RegisterHandler<TEvent>(Action<TEvent> handler) where TEvent : IDomainEvent
    {
        _handlers.Add(handler);
    }
}
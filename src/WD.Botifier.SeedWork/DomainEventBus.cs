using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WD.Botifier.SeedWork;

public class DomainEventBus
{
    private ICollection<Delegate> _handlers = new List<Delegate>();

    public void Emit(IDomainEvent @event)
    {
        foreach (var action in _handlers.Where(a => a.GetMethodInfo().GetParameters().FirstOrDefault()?.ParameterType == @event.GetType()))
            action.DynamicInvoke(@event);
    }

    public void RegisterHandler<TEvent>(Action<TEvent> handler) where TEvent : IDomainEvent
    {
        _handlers.Add(handler);
    }
}
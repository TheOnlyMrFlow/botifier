using System;

namespace WD.Botifier.SeedWork;

public interface IIntegrationEvent
{
    public string EmitterServiceName { get; }
    public DateTime OccuredOn { get; }
}
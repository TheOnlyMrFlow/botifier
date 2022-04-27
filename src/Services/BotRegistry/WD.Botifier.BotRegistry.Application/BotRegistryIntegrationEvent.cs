using System;
using WD.Botifier.SeedWork;

namespace WD.Botifier.BotRegistry.Application;

public class BotRegistryIntegrationEvent : IIntegrationEvent
{
    public string EmitterServiceName => "BotRegistry";
    public DateTime OccuredOn { get; protected set; } = DateTime.UtcNow;
}
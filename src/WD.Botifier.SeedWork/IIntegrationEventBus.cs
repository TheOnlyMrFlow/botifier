using System.Threading.Tasks;

namespace WD.Botifier.SeedWork;

public interface IIntegrationEventBus
{
    public Task PublishAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent;
}
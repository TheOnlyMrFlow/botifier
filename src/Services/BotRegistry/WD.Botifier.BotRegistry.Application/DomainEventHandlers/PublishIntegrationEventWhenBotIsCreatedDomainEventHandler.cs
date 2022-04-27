using System.Threading.Tasks;
using WD.Botifier.BotRegistry.Application.IntegrationEvents.Outgoing;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.RedditBots.Events;
using WD.Botifier.SeedWork;

namespace WD.Botifier.BotRegistry.Application.DomainEventHandlers;

public class PublishIntegrationEventWhenBotIsCreatedDomainEventHandler
{
    private readonly IIntegrationEventBus _integrationEventBus;

    public PublishIntegrationEventWhenBotIsCreatedDomainEventHandler(IIntegrationEventBus integrationEventBus)
    {
        _integrationEventBus = integrationEventBus;
    }

    public Task HandleAsync(RedditBotCreatedDomainEvent @event)
    {
        return _integrationEventBus.PublishAsync(new RedditBotCreatedIntegrationEvent(@event));
    }
}
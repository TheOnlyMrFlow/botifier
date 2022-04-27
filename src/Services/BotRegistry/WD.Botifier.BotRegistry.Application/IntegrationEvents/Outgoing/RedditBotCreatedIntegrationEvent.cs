using System;
using WD.Botifier.BotRegistry.Application.DTOs;
using WD.Botifier.BotRegistry.Domain.RedditBots.Events;

namespace WD.Botifier.BotRegistry.Application.IntegrationEvents.Outgoing;

public class RedditBotCreatedIntegrationEvent : BotRegistryIntegrationEvent
{
    public RedditBotCreatedIntegrationEvent(RedditBotCreatedDomainEvent domainEvent)
    {
        RedditBot = new RedditBotDto(domainEvent.RedditBot);
        OccuredOn = domainEvent.OccurredOn;
    }
    
    public RedditBotDto RedditBot { get; }
}
using System;
using WD.Botifier.SeedWork;

namespace WD.Botifier.BotRegistry.Domain.SharedKernel.Webhooks;

public interface IWebhook<TIdentifier> where TIdentifier : IIdValue
{
    TIdentifier Id { get; }
    
    WebhookSecret Secret { get; }
    
    Uri Url { get; }
}
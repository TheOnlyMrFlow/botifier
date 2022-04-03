using System;
using WD.Botifier.SeedWork;

namespace WD.Botifier.BotRegistry.Domain.SharedKernel.Webhooks;

public interface IWebhook<TIdentifier> where TIdentifier : IIdValue
{
    TIdentifier Id { get; }

    Uri Url { get; }
}
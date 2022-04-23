using System;
using WD.Botifier.SeedWork;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Domain.SharedKernel.Bots;

public interface IBot<out TIdentifier> where TIdentifier : IIdValue 
{
    TIdentifier Id { get; }
    
    BotName Name { get; }
    
    UserId OwnerId { get; }
    
    public DateTime CreatedAt { get; }
}
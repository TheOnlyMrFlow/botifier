using System;
using WD.Botifier.SeedWork;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Domain.Bots;

public class Bot : Entity, IAggregateRoot
{
    public Bot(BotId id, UserId ownerId, BotName name, DateTime createdAt)
    {
        Id = id;
        OwnerId = ownerId;
        Name = name;
        CreatedAt = createdAt;
    }
    
    public BotId Id { get; }
    
    public UserId OwnerId { get; }
    
    public BotName Name { get; } 
    
    public DateTime CreatedAt { get; }

    public static Bot NewBot(UserId ownerId, BotName name) => new(BotId.NewBotId(), ownerId, name, DateTime.UtcNow);
}
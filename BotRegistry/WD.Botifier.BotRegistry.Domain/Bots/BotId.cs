using System;
using WD.Botifier.SeedWork;

namespace WD.Botifier.BotRegistry.Domain.Bots;

public class BotId : IdValue
{
    public BotId(Guid value) : base(value) { }
    
    public static BotId NewBotId() => new(Guid.NewGuid());
}
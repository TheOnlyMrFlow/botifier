using System;
using WD.Botifier.SeedWork;

namespace WD.Botifier.SharedKernel;

public class UserId : IdValueBase
{
    public UserId(Guid value) : base(value) { }

    public static UserId NewUserId() => new(Guid.NewGuid());
}
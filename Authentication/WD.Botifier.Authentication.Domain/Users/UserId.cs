using WD.Botifier.SeedWork;

namespace WD.Botifier.Authentication.Domain.Users;

public class UserId : TypedIdValueBase
{
    public UserId(Guid value) : base(value)
    {
        
    }

    public static UserId NewUserId() => new(Guid.NewGuid());
}
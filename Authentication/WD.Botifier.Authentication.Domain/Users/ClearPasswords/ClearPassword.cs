using WD.Botifier.SeedWork;

namespace WD.Botifier.Authentication.Domain.Users.ClearPasswords;

public class ClearPassword : IEquatable<ClearPassword>
{
    public ClearPassword(string? value)
    {
        value ??= "";
        
        var brokenRule = new IBusinessRule[]
        {
            new PasswordMustBeatLeastTenCharactersRule(value),
            new PasswordMustHaveAtLeastOneLowercaseLetterRule(value),
            new PasswordMustHaveAtLeastOneUppercaseLetterRule(value),
            new PasswordMustHaveAtLeastOneSpecialCharacterRule(value),
        }.FirstOrDefault(rule => rule.IsBroken());

        if (brokenRule is not null)
            throw new BusinessRuleValidationException(brokenRule);
            
        Value = value;
    }

    public string Value { get; }

    public bool Equals(ClearPassword? other) => Value == other?.Value;

    public override bool Equals(object? obj) => obj is ClearPassword o && Equals(o);

    public override int GetHashCode() => HashCode.Combine(Value);

    public static bool operator ==(ClearPassword? left, ClearPassword? right) => left is not null && left.Equals(right);

    public static bool operator !=(ClearPassword left, ClearPassword right) => !(left == right);

    public override string ToString() => Value;
}

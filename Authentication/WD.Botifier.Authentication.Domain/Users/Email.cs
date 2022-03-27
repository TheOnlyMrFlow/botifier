using System.Globalization;
using System.Text.RegularExpressions;

namespace WD.Botifier.Authentication.Domain.Users;

public class Email : IEquatable<Email>
{
    public const int EmailMaxLength = 255;
            
    public Email(string? email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new EmailException();

        Value = email.Trim();

        if (Value.Length >= EmailMaxLength || !IsValidEmail(Value))
            throw new EmailException();
    }

    public string Value { get; }

    public bool Equals(Email? other) => Value == other?.Value;

    public override bool Equals(object? obj) => obj is Email o && Equals(o);

    public override int GetHashCode() => Value.GetHashCode();

    public static bool operator ==(Email? left, Email? right) => (left is null && right is null) || (left is not null && left.Equals(right));

    public static bool operator !=(Email left, Email right) => !(left == right);

    public override string ToString() => Value;

    private static bool IsValidEmail(string email)
    {
        try
        {
            email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));

            string DomainMapper(Match match)
            {
                var idn = new IdnMapping();

                var domainName = idn.GetAscii(match.Groups[2].Value);

                return match.Groups[1].Value + domainName;
            }
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
        catch (ArgumentException)
        {
            return false;
        }

        try
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }
}
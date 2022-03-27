using WD.Botifier.Authentication.Domain.Users;
using WD.Botifier.Authentication.Domain.Users.ClearPasswords;

namespace WD.Botifier.Authentication.Application.Users.Signup;

public class SignupCommand
{
    public SignupCommand(Email email, ClearPassword password)
    {
        Email = email;
        Password = password;
    }

    public Email Email { get; }
    
    public ClearPassword Password { get; }
}
using System.Threading.Tasks;
using OneOf;
using OneOf.Types;
using WD.Botifier.Authentication.Application.Ports;
using WD.Botifier.Authentication.Domain.Users;

namespace WD.Botifier.Authentication.Application.Users.Signup;

public class SignupCommandHandler
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordEncryptor _passwordEncryptor;

    public SignupCommandHandler(IUserRepository userRepository, IAccessTokenManager accessTokenManager, IPasswordEncryptor passwordEncryptor)
    {
        _userRepository = userRepository;
        _passwordEncryptor = passwordEncryptor;
    }
    
    public async Task<SignupCommandResult> HandleAsync(SignupCommand command)
    {
        if (await _userRepository.EmailExistsAsync(command.Email))
            return new SignupCommandEMailAlreadyTakenResult();

        var encryptedPassword = _passwordEncryptor.Encrypt(command.Password);

        var user = User.NewUser(command.Email, encryptedPassword);

        await _userRepository.AddAsync(user);

        return new Success();
    }
}
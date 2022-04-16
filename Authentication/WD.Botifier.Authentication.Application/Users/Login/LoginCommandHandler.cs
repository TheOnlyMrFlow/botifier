using System.Threading.Tasks;
using OneOf.Types;
using WD.Botifier.Authentication.Application.Ports;
using WD.Botifier.Authentication.Domain.Users;

namespace WD.Botifier.Authentication.Application.Users.Login;

public class LoginCommandHandler
{
    private readonly IUserRepository _userRepository;
    private readonly IAccessTokenManager _accessTokenManager;
    private readonly IPasswordEncryptor _passwordEncryptor;

    public LoginCommandHandler(IUserRepository userRepository, IAccessTokenManager accessTokenManager, IPasswordEncryptor passwordEncryptor)
    {
        _userRepository = userRepository;
        _accessTokenManager = accessTokenManager;
        _passwordEncryptor = passwordEncryptor;
    }
    
    public async Task<LoginCommandResult> HandleAsync(LoginCommand command)
    {
        var user = await _userRepository.FindUserByEmail(command.Email);
        if (user is null)
            return new Error();

        if (!_passwordEncryptor.ValidateClearPasswordAgainstEncrypted(command.Password, user.EncryptedPassword))
            return new Error();

        var accessToken = _accessTokenManager.Build(user);
        
        user.Login();
        await _userRepository.UpdateAsync(user);

        return new LoginCommandSuccessResult(accessToken);
    }
}
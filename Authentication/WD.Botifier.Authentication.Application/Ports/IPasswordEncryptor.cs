using WD.Botifier.Authentication.Domain.Users;
using WD.Botifier.Authentication.Domain.Users.ClearPasswords;
using WD.Botifier.Authentication.Domain.Users.EncryptedPasswords;

namespace WD.Botifier.Authentication.Application.Ports;

public interface IPasswordEncryptor
{
    EncryptedPassword Encrypt(ClearPassword clearPassword);

    bool ValidateClearPasswordAgainstEncrypted(ClearPassword clearPassword, EncryptedPassword encryptedPassword);
}
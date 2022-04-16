﻿using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using WD.Botifier.Authentication.Application.Ports;
using WD.Botifier.Authentication.Domain.Users.ClearPasswords;
using WD.Botifier.Authentication.Domain.Users.EncryptedPasswords;

namespace WD.Botifier.Authentication.Infrastructure.PasswordEncryptor;

public class PasswordEncryptor : IPasswordEncryptor
{
    public EncryptedPassword Encrypt(ClearPassword clearPassword)
    {
        var salt = B64Salt.NewSalt();
        var hash = GenerateHash(clearPassword, salt);

        return new EncryptedPassword(salt, hash);
    }
    
    public bool ValidateClearPasswordAgainstEncrypted(ClearPassword clearPassword, EncryptedPassword encryptedPassword)
    {
        var hash = GenerateHash(clearPassword, encryptedPassword.Salt);
        return hash == encryptedPassword.Hash;
    }

    private static string GenerateHash(ClearPassword password, B64Salt salt)
        => Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password.Value,
            salt.AsByteArray(),
            KeyDerivationPrf.HMACSHA1,
            100000,
            256 / 8)
        );
}
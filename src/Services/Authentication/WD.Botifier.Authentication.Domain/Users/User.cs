using System;
using WD.Botifier.Authentication.Domain.Users.EncryptedPasswords;
using WD.Botifier.SeedWork;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.Authentication.Domain.Users;

public class User : Entity, IAggregateRoot
{
    public User(UserId id, Email email, EncryptedPassword encryptedPassword, bool isEmailVerified, DateTime createdAt, DateTime? lastLoginAt)
    {
        Id = id;
        Email = email;
        EncryptedPassword = encryptedPassword;
        IsEmailVerified = isEmailVerified;
        CreatedAt = createdAt;
        LastLoginAt = lastLoginAt;
    }

    public static User NewUser(Email email, EncryptedPassword encryptedPassword) 
        => new (UserId.NewUserId(), email, encryptedPassword, false, DateTime.UtcNow, null);

    public UserId Id { get; }
    
    public Email Email { get; }
    
    public EncryptedPassword EncryptedPassword { get; }
    
    public bool IsEmailVerified { get; }
    
    public DateTime CreatedAt { get; }
    
    public DateTime? LastLoginAt { get; private set; }

    public void Login()
    {
        LastLoginAt = DateTime.UtcNow;
    }
}
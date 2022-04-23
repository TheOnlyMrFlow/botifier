using System;
using MongoDB.Bson.Serialization.Attributes;
using WD.Botifier.Authentication.Domain.Users;
using WD.Botifier.Authentication.Domain.Users.EncryptedPasswords;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.Authentication.Infrastructure.Persistence.MongoDb.Users;

[BsonIgnoreExtraElements]
public class UserDocument
{
    public UserDocument(User user)
    {
        Id = user.Id.Value;
        Email = user.Email.Value;
        PasswordHash = user.EncryptedPassword.ToString();
        IsEmailVerified = user.IsEmailVerified;
        CreatedAt = user.CreatedAt;
        LastLoginAt = user?.LastLoginAt;
    }

    public int SchemaVersion { get; set; } = 1;
    
    [BsonId]
    public Guid Id { get; set; }
    
    public string Email { get; set; }
    
    public string PasswordHash { get; set; }
    
    public bool IsEmailVerified { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? LastLoginAt { get; set; }

    public User ToUser() => new (new UserId(Id), new Email(Email), EncryptedPassword.Parse(PasswordHash), IsEmailVerified, CreatedAt, LastLoginAt);
}
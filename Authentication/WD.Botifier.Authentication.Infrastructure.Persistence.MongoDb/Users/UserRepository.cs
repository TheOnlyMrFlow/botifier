using System.Threading.Tasks;
using MongoDB.Driver;
using WD.Botifier.Authentication.Domain.Users;

namespace WD.Botifier.Authentication.Infrastructure.Persistence.MongoDb.Users;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<UserDocument> _userCollection;
    
    public UserRepository(BotifierAuthenticationMongoDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);

        _userCollection = database.GetCollection<UserDocument>(settings.UsersCollectionName);
    }

    public async Task AddAsync(User user)
    {
        var doc = new UserDocument(user);
        await _userCollection.InsertOneAsync(doc);
    }

    public Task UpdateAsync(User user)
    {
        return _userCollection.ReplaceOneAsync(u => u.Email == user.Email.Value, new UserDocument(user));
    }

    public async Task<bool> EmaiLExistsAsync(Email email)
        => await _userCollection.Find(u => u.Email == email.Value).AnyAsync();

    public async Task<User?> FindUserByEmail(Email email)
    {
        var userDoc = await _userCollection.Find(u => u.Email == email.Value).FirstOrDefaultAsync();
        return userDoc?.ToUser();
    }
}
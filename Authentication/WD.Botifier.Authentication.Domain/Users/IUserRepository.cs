using System.Threading.Tasks;
using WD.Botifier.SeedWork;

namespace WD.Botifier.Authentication.Domain.Users;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    
    Task<bool> EmaiLExistsAsync(Email email);
    
    Task<User?> FindUserByEmail(Email email);
}
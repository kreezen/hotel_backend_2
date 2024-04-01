using Domain.Users;
public interface IUserRepository
{
    Task<User> CreateUserAsync(User user);
    Task<User?> GetByUsernameAsync(string username);
    Task<User?> GetByIdAsync(Guid id);
    Task<bool> DoesUsernameExistAsync(string username);
    Task<List<User>> GetUsersBySubstringAsync(string substring);
    Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<User> AttachUser(User user);

}
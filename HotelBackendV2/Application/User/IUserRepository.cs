using Domain.Users;
public interface IUserRepository
{
    Task<User> CreateUserAsync(User user);
    Task<User?> GetByUsernameAsync(string username);
    Task<User?> GetByIdAsync(Guid id);
    Task<bool> doesUsernameExistAsync(string username);
}
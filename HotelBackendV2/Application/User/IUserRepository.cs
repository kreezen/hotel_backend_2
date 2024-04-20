using Domain.Users;
public interface IUserRepository
{
    Task<User> CreateUserAsync(User user);
    Task<List<User>> GetAllUsersAsync();
    Task<User?> GetByUsernameAsync(string username);
    Task<User?> GetByIdAsync(Guid id);
    Task<bool> DoesUsernameExistAsync(string username);
    Task<List<User>> GetUsersBySubstringAsync(string substring);


}
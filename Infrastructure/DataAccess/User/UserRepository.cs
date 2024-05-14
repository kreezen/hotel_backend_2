
using Domain.Users;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly HotelDbContext _dbContext;
    public UserRepository(HotelDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> DoesUsernameExistAsync(string username)
    {
        return await _dbContext.Users.AnyAsync(x => x.Username == username);
    }

    public async Task<User> CreateUserAsync(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == username);
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<User>> GetUsersBySubstringAsync(string substring)
    {
        var users = await _dbContext.Users.Where(x => x.Username.ToLower().Contains(substring.ToLower())).ToListAsync();
        return users;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<int> DeleteUserAsync(Guid id)
    {
        return await _dbContext.Users.Where(x => x.Id == id).ExecuteDeleteAsync();
    }
}
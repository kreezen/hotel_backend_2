
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
        var users = await _dbContext.Users.Where(x => x.Username.Contains(substring)).ToListAsync();
        return users;
    }

    public Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<User> AttachUser(User user) => _dbContext.Users.Attach(user);
}

using Domain.Users;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly HotelDbContext _dbContext;
    UserRepository(HotelDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> doesUsernameExistAsync(string username)
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
}
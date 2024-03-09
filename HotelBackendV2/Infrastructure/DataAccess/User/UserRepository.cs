public class UserRepository : IUserRepository
{
    private readonly HotelDbContext _dbContext;
    UserRepository(HotelDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<User> Create(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

    }

    public Task<User> GetByUsername(string username)
    {
        _dbContext.Users.FirstOrDefaultAsync(x => x.Username == username);
    }

    public Task<User> GetById(Guid id)
    {
        _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
    }
}
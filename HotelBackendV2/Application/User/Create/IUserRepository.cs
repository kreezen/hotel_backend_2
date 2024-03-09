namespace Application.Abstractions.Repositories;
public interface IUserRepository
{
    Task<User> Create(user user);
    Task<User> GetByUsername(string username);
    Task<User> GetById(Guid id);

}
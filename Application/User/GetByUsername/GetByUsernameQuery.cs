
using Domain.Users;

public class GetByUsernameQuery : IQuery<User>
{
    public required string Username { get; set; }
}


using Domain.Users;


public class CreateUserCommand : ICommand<User>
{
    public required string Username { get; set; }
}


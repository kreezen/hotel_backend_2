using Domain.Users;

public class DeleteUserCommand : ICommand<User>
{
    public Guid Id { get; set; }
}
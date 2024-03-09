using Application.Abstractions.Messaging;

namespace Application.Userr.Create;

public class CreateUserCommand : ICommand
{
    public required string Username { get; set; }
}


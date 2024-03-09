namespace Application.User.Create;

public class CreateUserHandler : ICommandHandler<CreateUserCommand>
{
    private readonly IUserRepository _userRepository;
    CreateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // Create user logic
        return Task.FromResult(Unit.Value);
    }
}

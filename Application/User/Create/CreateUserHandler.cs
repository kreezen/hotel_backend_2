
using Domain.Users;
using SharedKernel;

public class CreateUserHandler : ICommandHandler<CreateUserCommand, User>
{
    private readonly IUserRepository _userRepository;
    public CreateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<Result<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(Guid.NewGuid(), request.Username);

        var doesUserExist = await _userRepository.DoesUsernameExistAsync(user.Username);
        if (doesUserExist)
        {
            return Result.Failure<User>(Error.Conflict("User.Conflict", "User already exists"));
        }
        return await _userRepository.CreateUserAsync(user);
    }
}


using Domain.Users;
using SharedKernel;

public class DeleteUserHandler : ICommandHandler<DeleteUserCommand, User>
{
    private readonly IUserRepository _userRepository;
    public DeleteUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<SharedKernel.Result<User>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user == null)
        {
            return Result.Failure<User>(Error.NotFound("User.NotFound", "User not found"));
        }

        await _userRepository.DeleteUserAsync(request.Id);
        return user;
    }
}
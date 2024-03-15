
using Domain.Users;
using SharedKernel;


public class GetByUsernameHandler : IQueryHandler<GetByUsernameQuery, User>
{
    private readonly IUserRepository _userRepository;

    public GetByUsernameHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<User>> Handle(GetByUsernameQuery query, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByUsernameAsync(query.Username);
        if (user == null)
        {
            return (Result<User>)Result<User>.Failure(Error.NotFound("User.NotFound", "User not found"));
        }

        return Result<User>.Success(user);
    }


}

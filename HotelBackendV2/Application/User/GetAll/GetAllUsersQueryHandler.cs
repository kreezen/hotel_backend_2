
using Domain.Users;

public class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, List<User>>
{
    private readonly IUserRepository _userRepository;
    public GetAllUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<SharedKernel.Result<List<User>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetAllUsersAsync();
    }
}
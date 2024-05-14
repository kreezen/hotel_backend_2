
using Domain.Users;

public class SeachByUserHandler : IQueryHandler<SearchByUserQuery, List<User>>
{
    private readonly IUserRepository _userRepository;
    //TODO make SearchServie or Repo later, if needed
    public SeachByUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<SharedKernel.Result<List<User>>> Handle(SearchByUserQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetUsersBySubstringAsync(request.Username);
        return users;
    }
}
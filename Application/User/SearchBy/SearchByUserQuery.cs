using Domain.Users;

public class SearchByUserQuery : IQuery<List<User>>
{
    public required string Username { get; set; }
}
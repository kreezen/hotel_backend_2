
using Domain.Users;
using Task = Domain.Activities.Task;


public class GetByUserQuery : IQuery<IEnumerable<Task>>
{
    public required User User { get; set; }
}


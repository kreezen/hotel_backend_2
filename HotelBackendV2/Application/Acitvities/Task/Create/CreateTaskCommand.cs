
using Domain.Users;
using Task = Domain.Activities.Task;

public class CreateTaskCommand : ICommand<Task>
{
    public required Guid CustomerId { get; set; }
    public required string Description { get; set; }
    public DateTime DueDate { get; set; }
    public required User CreatedBy { get; set; }
    public required User AssignedTo { get; set; }

}

using Domain.Users;
using Task = Domain.Activities.Task;
public class UpdateTaskCommand : ICommand<Task>
{
    public Guid Id { get; set; }
    public required string Description { get; set; }
    public required User ModifiedBy { get; set; }
    public required User AssignedTo { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
}
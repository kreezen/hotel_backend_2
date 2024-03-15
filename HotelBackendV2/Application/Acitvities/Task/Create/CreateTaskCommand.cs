
using Domain.Users;
using Task = Domain.Activities.Task;

public class CreateTaskCommand : ICommand<Task>
{
    public required string Description { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
    public DateTime DueDate { get; set; }
    public required User CreatedBy { get; set; }
    public required User ModifiedBy { get; set; }
    public Boolean IsCompleted { get; set; }
    public required User AssignedTo { get; set; }

}
